using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;
using MenaxhimiKinemas.Abstraction;
using System.IO;

namespace MenaxhimiKinemas
{
    public class Tickets : Name
    {
        //creates a new ticket id
        Guid TicketId = Guid.NewGuid();
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Seat { get; set; }
        public DateTime Date { get; set; }
        public string Price { get; set; }
        public string EventName { get; set; }
        public string EventTime { get; set; }

        //this constructor validates if the data is null or empty
        public Tickets(string movieName, string userName, string phoneNumber, string seat, DateTime date, string price)
        {
            if (!string.IsNullOrEmpty(movieName) && !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(phoneNumber) && !string.IsNullOrEmpty(seat) && !string.IsNullOrEmpty(price))
            {
                Name_ = movieName;
                UserName = userName;
                PhoneNumber = phoneNumber;
                Seat = seat;
                Date = date;
                Price = price;
            }
            else
            {
                throw new Exception("Make sure that all your entries are correct!");
            }

            //checks to not allow date to be picked less than today
            if (Date < DateTime.Now)
            {
                throw new Exception($"Please enter a date more than today {DateTime.Now.ToLongDateString()}!");
            }
           
        }

        public Tickets(string eventName, DateTime date, string userName, string price, string eventTime)
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

        //this method displayes the full ticket
        public string ShowTicket()
        {
            return $"Your ticket ID is: {TicketId}\n\nMovie picked out: {Name_}\n" +
                $"Your name: {UserName}\nContact number: {PhoneNumber}\nSeat: {Seat}\n" +
                $"Date: {Date.ToLongDateString()}\nPrice: {Price}";
        }

        public void SaveTicketToFile()
        {
            string filepath = "./Data/TicketForMovie.txt";

            string fullTicket = $"Your ticket ID is: {TicketId},Movie Name is: {Name_},Your name: {UserName},Contact number: {PhoneNumber}" +
                $",Seat: {Seat}Date: {Date.ToLongDateString()},Price: {Price}";

            File.AppendAllText(filepath, fullTicket + Environment.NewLine);
        }

        public string ShowEventTicket()
        {
            return $"Your ticket ID is: {TicketId}\n\nMovie Name is: {EventName}\n" +
                $"Your name: {UserName}\nDate: {Date.ToLongDateString()}\nTime scheduled: {EventTime}\nPrice: {Price}";
        }

        public void SaveEventTicketToFile()
        {
            string filepath = "./Data/EventTicket.txt";

            string fullEventTicket = $"{TicketId}, {EventName}, {UserName}, {Date.ToLongDateString()}, {EventTime} {Price}";

            File.AppendAllText(filepath, fullEventTicket + Environment.NewLine);
        }

        

    }
}
