using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenaxhimiKinemas
{
    public class Technology
    {
        string TechType;

        //The constructor checks if the parameter is null or empty
        public Technology(string techType)
        {
            if (!string.IsNullOrEmpty(techType))
            {
                TechType = techType;
            }
            else
            {
                throw new Exception("Please enter a technology for the movie!");
            }
        }

        //This method returns the value
        public string ShowTech()
        {
            return TechType;
        }
    }
}



   
