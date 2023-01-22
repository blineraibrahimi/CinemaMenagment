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
    public class MovieTicket : ITicket
    {
        //creates a new ticket id
        Guid TicketId = Guid.NewGuid();
        public string MovieName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Seat { get; set; }
        public DateTime Date { get; set; }
        public string Price { get; set; }
       

        //this constructor validates if the data is null or empty
        public MovieTicket(string movieName, string userName, string phoneNumber, string seat, DateTime date, string price)
        {
            if (!string.IsNullOrEmpty(movieName) && !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(phoneNumber) && !string.IsNullOrEmpty(seat) && !string.IsNullOrEmpty(price))
            {
                MovieName = movieName;
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

     

        //this method displayes the full ticket
        public string ShowTicket()
        {
            return $"Your ticket ID is: {TicketId}\n\nMovie picked out: {MovieName}\n" +
                $"Your name: {UserName}\nContact number: {PhoneNumber}\nSeat: {Seat}\n" +
                $"Date: {Date.ToLongDateString()}\nPrice: {Price}";
        }

        public void SaveTicketToFile()
        {
            string filepath = "./Data/TicketForMovie.txt";

            string fullTicket = $"Your ticket ID is: {TicketId},Movie Name is: {MovieName},Your name: {UserName},Contact number: {PhoneNumber}" +
                $",Seat: {Seat}Date: {Date.ToLongDateString()},Price: {Price}";

            File.AppendAllText(filepath, fullTicket + Environment.NewLine);
        }

        

    }
}
