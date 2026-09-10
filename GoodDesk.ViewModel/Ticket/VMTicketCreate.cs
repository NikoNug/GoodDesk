using System;
using System.Collections.Generic;
using System.Text;

namespace GoodDesk.ViewModel.Ticket
{
    public class VMTicketCreate
    {
        public string Subject { get; set; } = null!;
        public string? Description { get; set; }

        public int CategoryID { get; set; }
        public int PriorityID { get; set; }
    }
}
