using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MenaxhimiKinemas
{
    public class Movies
    {
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public int MovieLength { get; set; }
        public DateTime LaunchYear { get; set; }
        public bool SafeForKids { get; set; } = false;
        public double Price { get; set; }
        public List<MovieTicket> tickets { get; set; }
        public Genre Category { get; set; }
        public Technology Tech { get; set; }
        public enum Genre
        {
            Action,
            Adventure,
            Comedy,
            Crime,
            Drama,
            Fantasy,
            Horror,
            Romance,
            SciFi,
            Thriller,
            Barbie,
            None
        }

        public enum Technology
        {
            _2D,
            _3D,
            None
        }



        //The constructor checks if the parameter is null or empty
        public Movies(string movieName, string movieDescription, DateTime launchYear, int movieLength, bool safeForKids, double price, Genre category, Technology technology)
        {
            if (!string.IsNullOrEmpty(movieName) || !string.IsNullOrEmpty(movieDescription)
                || !string.IsNullOrEmpty(movieDescription)
                || movieLength < 0)
            {
                this.MovieName = movieName;
                this.MovieDescription = movieDescription;
                this.MovieLength = movieLength;
                this.SafeForKids = safeForKids;
                this.Price = price;
                this.Category = category;
                this.Tech = technology;
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