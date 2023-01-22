using MenaxhimiKinemas.Abstraction;
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
    public class Subscription : Name
    {
        public string Email { get; set; }

        //default true for 1 month subscription
        public bool SubscriptionType { get; set; } = true;


        public Subscription(string fullname, string email, bool subscriptionType)
        {
            Name_ = fullname;
            Email = email;
            SubscriptionType = subscriptionType;
        }

        public void SaveSubscriptionToFile()
        {
            string subType = "";

            if (SubscriptionType == true)
            {
                subType = "1 month subscription with 15% off";
            }
            else if (SubscriptionType == false)
            {
                subType = "1 year subscription with 30% off";
            }

            string filepath = "./Data/Subscription.txt";

            string fullSubscription = $"{Name_}\nEmail: {Email}\n has {subType}!";

            File.AppendAllText(filepath, fullSubscription + Environment.NewLine);

        }

    }
}
