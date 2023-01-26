using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Windows.Forms;

namespace MenaxhimiKinemas
{
    public class Review
    {
        public string MovieName { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; } = 0;

        public Review(string movieName, string comment, int rating)
        {
            if (!string.IsNullOrEmpty(movieName) || !string.IsNullOrEmpty(comment))
            {
                MovieName = movieName;
                Comment = comment;
                Rating = rating;
            }

            if (rating >= 0 || rating <= 5)
            {
                Rating = rating;
            }
            else
            {
                MessageBox.Show("Please enter a rating from 0 - 5");
            }
        }

        public void SaveReviewToFile()
        {
            string filepath = "./Data/review.txt";

            string fullReview = $"'{MovieName}', {Comment}, has {Rating} star rating";

            File.AppendAllText(filepath, fullReview + Environment.NewLine);
        }
    }
}