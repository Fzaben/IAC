using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp;
using Abp.Domain.Entities;

namespace MyCompanyName.AbpZeroTemplate.Storage
{
    [Table("AppBinaryObjects")]
    public class BinaryObject : Entity<Guid>, IMayHaveTenant
    {
        public BinaryObject()
        {
            Id = SequentialGuidGenerator.Instance.Create();
        }

        public BinaryObject(int? tenantId, byte[] bytes, string description = null)
            : this()
        {
            TenantId = tenantId;
            Bytes = bytes;
            Description = description;
        }

        public virtual string Description { get; set; }

        [Required] public virtual byte[] Bytes { get; set; }
        public virtual int? TenantId { get; set; }
    }
}