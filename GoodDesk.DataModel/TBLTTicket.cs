using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GoodDesk.DataModel
{
    [Table("TBL_T_Tickets")]
    public class TBLTTicket
    {
        public int ID { get; set; }

        [Required, MaxLength(50)]
        public string TicketNumber { get; set; } = null!;

        [Required, MaxLength(50)]
        public string Subject { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        public int RequesterID { get; set; }

        public int? AssignedToID { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        public int PriorityID { get; set; }

        [Required]
        public int StatusID { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? ResolvedDate { get; set; }

        public DateTime? ClosedDate { get; set; }

        // Navigation Properties
        public TBLMUser Requester { get; set; } = null!;
        public TBLMUser? AssignedTo { get; set; } = null!;
        public TBLMCategory Category { get; set; } = null!;
        public TBLMPriority Priority { get; set; } = null!;
        public TBLMStatus Status { get; set; } = null!;

    }
}
