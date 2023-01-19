using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenaxhimiKinemas
{
    public class Genre
    {
        string Genre_;

        //The constructor checks if the parameter is null or empty
        public Genre(string genre)
        {
            if (!string.IsNullOrEmpty(genre))
            {
                Genre_ = genre;
            }
            else
            {
                throw new Exception("Please enter a genre for the movie!");
            }
        }

        //This method returns the value
        public string ShowGenre()
        {
            return Genre_;
        }

    }
}
