using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GoodDesk.DataModel
{
    [Table("TBL_M_Roles")]
    public class TBLMRole
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(50)]
        public string RoleName { get; set; } = null!;

        [MaxLength(255)]
        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public ICollection<TBLMUser> Users { get; set; } = new List<TBLMUser>();
    }
}
