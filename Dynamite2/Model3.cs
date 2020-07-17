﻿﻿﻿﻿using System;
 using System.Collections.Generic;
using System.Linq;
using BotInterface.Game;

namespace DynamiteTest
{
    public class Model3
    {
        // String length/ String/ predicted char/ List of each round char was discovered after string
        private Dictionary<int, Dictionary<string, Dictionary<char, List<int>>>> charFrequency { get; set; }
        public Dictionary<char, double> predictionDictionary { get; set; }
        private Dictionary<int, Dictionary<string, Dictionary<char, double>>> charProbabilities { get; set; }


        public void TrainDictionary(Round[] xnyn, string xn, string yn, int generalMaxSubStringLen)
        {
            charFrequency = new Dictionary<int, Dictionary<string, Dictionary<char, List<int>>>>();
            for (int i = 0; i < xnyn.Count(); i++)
            {
                int maxSubStringLen = new List<int> {xnyn.Count() - i, generalMaxSubStringLen}.Min();

                for (int j = 2; j < maxSubStringLen; j++)
                {
                    string xListPreceding = xn.Substring(i, j);
                    char yOutput = yn[i + j];
                    
                    charFrequency = FormattingClass.FormatDictionaryModel3(charFrequency, j, xListPreceding, yOutput);
                    
                    charFrequency[j][xListPreceding][yOutput].Add(xnyn.Count());
                }
            }
        }

        public void PredictDictionary(string xn, int generalMaxSubStringLen)
        {
            predictionDictionary = new Dictionary<char, double>();
            for (int j = 2; j < generalMaxSubStringLen; j++)
            {
                if (!charFrequency[j].ContainsKey(xn.Substring(xn.Length - j))) continue;
                foreach (var move in new List<char> {'R', 'P', 'S', 'W', 'D'})
                {
                    if (!predictionDictionary.ContainsKey(move)) predictionDictionary.Add(move, 0);
                    if (!charFrequency[j][xn.Substring(xn.Length - j)].ContainsKey(move)) continue;

                    predictionDictionary[move] += GetProbFromCharHistory(charFrequency[j][xn.Substring(xn.Length - j)][move], xn.Length);
                }
            }
        }

        private double GetProbFromCharHistory(List<int> charDiscoveryTurns, int currentTurn)
        {
            double relevance = 0;
            foreach (var charDiscoveryTurn in charDiscoveryTurns)
            {
                relevance += Math.Pow(currentTurn - charDiscoveryTurn, -0.25);
            }

            return relevance;
        }

        /*
        public void PrintPredictionDictionary()
        {
            Console.WriteLine("Prediction Dictionary");
            foreach (var move in predictionDictionary)
            {
                Console.WriteLine(move.Key+":   "+move.Value);
            }
        }
        */
    }
}