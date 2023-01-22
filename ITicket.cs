using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MenaxhimiKinemas
{
    interface ITicket
    {
        //Guid TicketId { get; set; }
        string MovieName { get; set; }
        string UserName { get; set; }
        DateTime Date { get; set; }
        string Price { get; set; }

        string ShowTicket();
        void SaveTicketToFile();
    }
}
