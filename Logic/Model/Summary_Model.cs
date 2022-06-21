using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSDesk_CLI_API.Model
{
    public class TicketCount_ByType_Model
    {
        public string Name { get; set; }
        public int OpenTickets { get; set; }
        public int ReceivedTickets { get; set; }
        public int ClosedTickets { get; set; }
        public int OverDueTickets { get; set; }
        public int Count { get; set; }
    }
    public class TicketReceived_ByDays_Model
    {       
        public int DayNo { get; set; }
        public int ViolatedTickets { get; set; }
        public int NonViolatedTickets { get; set; }
    }



}
