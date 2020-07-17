﻿﻿﻿﻿using System;
   using System.Collections.Generic;
   using System.Linq;
   using BotInterface.Game;

namespace DynamiteTest
{
    public class FormattingClass
    {
        public static Dictionary<int, Dictionary<string, Dictionary<char, int>>> FormatDictionary(Dictionary<int, Dictionary<string, Dictionary<char, int>>> stringFrequency, int j, string xListPreceding, char yOutput)
        {
            if (!stringFrequency.ContainsKey(j))
            {
                stringFrequency.Add(j, new Dictionary<string, Dictionary<char, int>>());
            }
            
            if (!stringFrequency[j].ContainsKey(xListPreceding))
            {
                stringFrequency[j].Add(xListPreceding, new Dictionary<char, int>());
            }

            if (!stringFrequency[j][xListPreceding].ContainsKey(yOutput))
            {
                stringFrequency[j][xListPreceding].Add(yOutput, 0);
            }

            return stringFrequency;
        }
        
        public static Dictionary<int, Dictionary<string, Dictionary<char, List<int>>>> FormatDictionaryModel3(Dictionary<int, Dictionary<string, Dictionary<char, List<int>>>> stringFrequency, int j, string xListPreceding, char yOutput)
        {
            if (!stringFrequency.ContainsKey(j))
            {
                stringFrequency.Add(j, new Dictionary<string, Dictionary<char, List<int>>>());
            }
            
            if (!stringFrequency[j].ContainsKey(xListPreceding))
            {
                stringFrequency[j].Add(xListPreceding, new Dictionary<char, List<int>>());
            }

            if (!stringFrequency[j][xListPreceding].ContainsKey(yOutput))
            {
                stringFrequency[j][xListPreceding].Add(yOutput, new List<int>());
            }

            return stringFrequency;
        }

        public static List<string> FormatXNYN(Round[] xnyn)
        {
            var xn = "";
            var yn = "";

            foreach (var xiyi in xnyn)
            {
                xn += xiyi.GetP1().ToString();
                yn += xiyi.GetP2().ToString();
            }
            
            return new List<string>{xn, yn};
        }
    }
}