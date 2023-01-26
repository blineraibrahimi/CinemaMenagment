using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Web;

namespace MenaxhimiKinemas
{
    public class Subscription : Personi.Personi
    {
        public string Email { get; set; }

        //default true for 1 month subscription
        public bool SubscriptionType { get; set; } = true;

        public Subscription(int id, string name, string lastname, string personalNo, DateTime birthdate, string email, bool subscriptionType)
        {
            PersoniId = id;
            Emri = name;
            Mbiemri = lastname;
            NrPersonal = personalNo;
            DateLindja = birthdate;

            Email = email;
            SubscriptionType = subscriptionType;
        }
    }
}
