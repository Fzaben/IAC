using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.BackgroundJobs;
using Abp.IO.Extensions;
using Abp.Runtime.Session;
using Abp.UI;
using Abp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using MyCompanyName.AbpZeroTemplate.Authorization;
using MyCompanyName.AbpZeroTemplate.Authorization.Users.Dto;
using MyCompanyName.AbpZeroTemplate.Authorization.Users.Importing;
using MyCompanyName.AbpZeroTemplate.Storage;

namespace MyCompanyName.AbpZeroTemplate.Web.Controllers
{
    public abstract class UsersControllerBase : AbpZeroTemplateControllerBase
    {
        protected readonly IBackgroundJobManager BackgroundJobManager;
        protected readonly IBinaryObjectManager BinaryObjectManager;

        protected UsersControllerBase(
            IBinaryObjectManager binaryObjectManager,
            IBackgroundJobManager backgroundJobManager)
        {
            BinaryObjectManager = binaryObjectManager;
            BackgroundJobManager = backgroundJobManager;
        }

        [HttpPost]
        [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users_Create)]
        public async Task<JsonResult> ImportFromExcel()
        {
            try
            {
                var file = Request.Form.Files.First();

                if (file == null) throw new UserFriendlyException(L("File_Empty_Error"));

                if (file.Length > 1048576 * 100) //100 MB
                    throw new UserFriendlyException(L("File_SizeLimit_Error"));

                byte[] fileBytes;
                using (var stream = file.OpenReadStream())
                {
                    fileBytes = stream.GetAllBytes();
                }

                var tenantId = AbpSession.TenantId;
                var fileObject = new BinaryObject(tenantId, fileBytes, $"{DateTime.UtcNow} import from excel file.");

                await BinaryObjectManager.SaveAsync(fileObject);

                await BackgroundJobManager.EnqueueAsync<ImportUsersToExcelJob, ImportUsersFromExcelJobArgs>(
                    new ImportUsersFromExcelJobArgs
                    {
                        TenantId = tenantId,
                        BinaryObjectId = fileObject.Id,
                        User = AbpSession.ToUserIdentifier()
                    });

                return Json(new AjaxResponse(new { }));
            }
            catch (UserFriendlyException ex)
            {
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
    }
}