using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.IO;

namespace MenaxhimiKinemas
{
    public class EventTicket : ITicket
    {

        Guid TicketId = Guid.NewGuid();
        public string EventName { get; set; }
        public string MovieName { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public string Price { get; set; }
        public string EventTime { get; set; }


        public EventTicket(string eventName, DateTime date, string userName, string price, string eventTime)
        {
            if (!string.IsNullOrEmpty(eventName) && !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(price) && !string.IsNullOrEmpty(eventTime))
            {
                EventName = eventName;
                Date = date;
                UserName = userName;
                Price = price;
                EventTime = eventTime;
            }
            else
            {
                throw new Exception("Make sure that all your entries are correct!");
            }
        }

        public void SaveTicketToFile()
        {
            string filepath = "./Data/EventTicket.txt";

            string fullEventTicket = $"{TicketId}, {EventName}, {UserName}, {Date.ToLongDateString()}, {EventTime} {Price}";

            File.AppendAllText(filepath, fullEventTicket + Environment.NewLine);
        }

        public string ShowTicket()
        {
            return $"Your ticket ID is: {TicketId}\n\nMovie Name is: {EventName}\n" +
               $"Your name: {UserName}\nDate: {Date.ToLongDateString()}\nTime scheduled: {EventTime}\nPrice: {Price}";
        }
    }
}
