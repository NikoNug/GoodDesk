using System;
using System.Collections.Generic;
using System.Text;

namespace GoodDesk.ViewModel.Ticket
{
    public class VMTicketList
    {
        public int ID { get; set; }
        public string TicketNumber { get; set; } = null!;
        public string Subject { get; set; } = null!;

        public string Requester { get; set; } = null!;
        public string? AssignedTo { get; set; }

        public string Category { get; set; } = null!;
        public string Priority { get; set; } = null!;
        public string Status { get; set; } = null!;

        public DateTime CreatedDate { get; set; }
    }
}
