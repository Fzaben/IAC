using System.Threading.Tasks;
using DevOps.Models.TokenAuth;
using DevOps.Web.Controllers;
using Shouldly;
using Xunit;

namespace DevOps.Web.Tests.Controllers
{
    public class HomeController_Tests: DevOpsWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}