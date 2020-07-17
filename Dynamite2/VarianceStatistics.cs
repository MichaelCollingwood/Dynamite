﻿﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamiteTest
{
    public class VarianceStatistics
    {
        private static double FindStdv(Dictionary<char, int> stringCharacteristics)
        {
            // per string
            var frequencyStringStats = new List<double>();
            foreach(KeyValuePair<char, int> entry in stringCharacteristics)
            {
                frequencyStringStats.Add(entry.Value);
            }

            return CalculateStandardDeviation(frequencyStringStats);
        }
        
        private static double CalculateStandardDeviation(IEnumerable<double> values)
        {   
            double standardDeviation = 0;

            if (values.Any()) 
            {      
                // Compute the average.     
                double avg = values.Average();

                // Perform the Sum of (value-avg)_2_2.      
                double sum = values.Sum(d => Math.Pow(d - avg, 2));

                // Put it all together.      
                standardDeviation = Math.Sqrt((sum) / (values.Count()-1));   
            }  

            return standardDeviation;
        }
    }
}