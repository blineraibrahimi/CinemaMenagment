using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenaxhimiKinemas
{
    public class TicketComboBox : ITicketComboBox
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public TicketComboBox(string name, int value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}