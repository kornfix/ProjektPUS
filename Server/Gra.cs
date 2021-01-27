using System;
using System.Collections.Generic;

namespace Server
{
    class Gra
    {
        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k", "b", "b", "v", "v", "w", "w", "z", "z"
        };
        Random rnd = new Random();

        public string WylosowaniePlanszy()
        {
            int randomNumber;
            string WylosowanaTablica = "";

            for (int i = 0; i < 16; i++)
            {
                randomNumber = rnd.Next(0, icons.Count);
                if (i == 15)
                {
                    WylosowanaTablica += (i).ToString() + ":" + icons[randomNumber];
                }
                else
                {
                    WylosowanaTablica += (i).ToString() + ":" + icons[randomNumber] + " ";
                }

                icons.RemoveAt(randomNumber);
            }
            return WylosowanaTablica;
        }
    }
}
