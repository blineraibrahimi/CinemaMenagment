using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MenaxhimiKinemas
{
    //Polymorphism
    interface ITicket
    {
        string MovieName { get; set; }
        string UserName { get; set; }
        DateTime Date { get; set; }
        string Price { get; set; }

        string ShowTicket();
        void SaveTicketToFile();
    }

    interface ITicketComboBox
    {
        string Name { get; set; }
        int Value { get; set; }
    }
}
