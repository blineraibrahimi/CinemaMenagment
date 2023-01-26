using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenaxhimiKinemas
{
    public class TheatreRoom
    {
        string TheatreRoomName;
        int NumberOfChairs;

        //The constructor checks if the parameters is null or empty
        public TheatreRoom(string theatreRoomName, int numberOfChairs)
        {
            if (!string.IsNullOrEmpty(theatreRoomName))
            {
                TheatreRoomName = theatreRoomName;
                NumberOfChairs = numberOfChairs;
            }
            else
            {
                throw new Exception("Please enter a movie name!");
            }
        }

        //This method returns the value + added text
        public string ShowValues()
        {
            return $"Theatre Room Name: {TheatreRoomName}\nNumber of chairs: {NumberOfChairs}";
        }
    }
}