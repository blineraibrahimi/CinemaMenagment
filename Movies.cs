using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenaxhimiKinemas.Abstraction;


namespace MenaxhimiKinemas
{
    public class Movies : Name
    {
        //public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public int MovieLength { get; set; }
        public DateTime LaunchYear { get; set; }
        public bool SafeForKids { get; set; } = false;
        public double Price { get; set; }
         
        public List<MovieTicket> tickets { get; set; }


        //The constructor checks if the parameter is null or empty
        public Movies(string movieName, string movieDescription, DateTime launchYear, int movieLength, bool safeForKids, double price)
        {
            if (!string.IsNullOrEmpty(movieName) || !string.IsNullOrEmpty(movieDescription)
                || !string.IsNullOrEmpty(movieDescription)
                || movieLength < 0)
            {
                //this.MovieName = movieName;
                Name_ = movieName;
                this.MovieDescription = movieDescription;
                this.MovieLength = movieLength;
                this.SafeForKids = safeForKids;
                this.Price = price;
            }
            else
            {
                throw new Exception("Please enter a movie name!");
            }

            if (launchYear <= DateTime.Now)
            {
                LaunchYear = launchYear;
            }
            else
            {
                throw new Exception("Please pick a new date!");
            }

            tickets = new List<MovieTicket>();
            Console.WriteLine(tickets.Count);
        }
    }
}