using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodDesk.DataModel
{
    [Table("TBL_M_Users")]
    public class TBLMUser
    {
        [Key]
        public int ID { get; set; }
        [Required, MaxLength(50)]
        public string Username { get; set; } = null!;
        [Required, MaxLength(100)]
        public string Email { get; set; } = null!;
        [Required]
        public string PasswordHash { get; set; } = null!;
        [Required]
        public int RoleID { get; set; }
        public TBLMRole Role { get; set; } = null!;
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate {  get; set; }
        public int? UpdatedBy {  get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
