using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GoodDesk.DataModel
{
    [Table("TBL_M_Statuses")]
    public class TBLMStatus
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(50)]
        public string StatusName { get; set; } = null!;

        [MaxLength(255)]
        public string? Description { get; set; }

        public int Level { get; set; }

        public bool IsActive { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public ICollection<TBLTTicket> Tickets { get; set; }
            = new List<TBLTTicket>();
    }
}
