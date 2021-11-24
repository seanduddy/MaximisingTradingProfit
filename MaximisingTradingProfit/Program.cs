using System;
using System.Collections.Generic;

namespace MaximisingTradingProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary to store date and value of asset.
            //Load test data into dictionary.
            var priceDates = new Dictionary<DateTime, int>()
            {
                {new DateTime(2021, 01, 01), 23},
                {new DateTime(2021, 02, 01), 11},
                {new DateTime(2021, 03, 01), 76},
                {new DateTime(2021, 04, 01), 84},
                {new DateTime(2021, 05, 01), 9},
                {new DateTime(2021, 06, 01), 106},
                {new DateTime(2021, 07, 01), 107},
                {new DateTime(2021, 08, 01), 106},
                {new DateTime(2021, 09, 01), 9},
                {new DateTime(2021, 10, 01), 20}
            };

            //Initalise variables.
            var maxDiff = new int();
            var lDate = new DateTime();
            var rDate = new DateTime();

            //Loop through each date starting from the first date.
            foreach (KeyValuePair<DateTime, int> priceDateLeft in priceDates) 
            {
                //Loop through every date after and find the biggest difference in price we can.
                foreach (KeyValuePair<DateTime, int> priceDateRight in priceDates)
                {
                    //Not interested in anything before or equal to the leftmost date.
                    if (priceDateLeft.Key <= priceDateRight.Key)
                    {
                        //Calc difference.
                        var difference = priceDateRight.Value - priceDateLeft.Value;
                        if (difference > maxDiff)
                        {
                            //Set output variables.
                            maxDiff = difference;
                            lDate = priceDateLeft.Key;
                            rDate = priceDateRight.Key;

                        };
                    }
                }
            }

            //Print results and final readkey to prevent console disappearing.
            Console.WriteLine(string.Concat(maxDiff," difference "));
            Console.WriteLine(string.Concat("The best date to buy was: ", lDate));
            Console.WriteLine(string.Concat("The best time to sell was: ", rDate));
            Console.ReadKey();

        }
    }
}
