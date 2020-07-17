﻿﻿﻿﻿using System;
 using System.Collections.Generic;
using System.Linq;
using BotInterface.Game;

namespace DynamiteTest
{
    public class Model2
    {
        private Dictionary<int, Dictionary<string, Dictionary<char, int>>> charFrequency { get; set; }
        private Dictionary<int, Dictionary<string, Dictionary<char, double>>> charProbabilities { get; set; }
        public Dictionary<char, double> predictionDictionary { get; set; }

        public void TrainDictionary(Round[] xnyn, string xn, string yn, int generalMaxSubStringLen)
        {
            charFrequency = new Dictionary<int, Dictionary<string, Dictionary<char, int>>>();
            for (int i = 0; i < xnyn.Count(); i++)
            {
                int maxSubStringLen = new List<int> {xnyn.Count() - i, generalMaxSubStringLen}.Min();

                for (int j = 2; j < maxSubStringLen; j++)
                {
                    string xListPreceding = xn.Substring(i, j);
                    char yOutput = yn[i + j];
                    
                    charFrequency = FormattingClass.FormatDictionary(charFrequency, j, xListPreceding, yOutput);
                    
                    charFrequency[j][xListPreceding][yOutput] += 1;
                }
            }
            GetCharProbsFromFreqs();
        }

        public void PredictDictionary(string xn, int generalMaxSubStringLen)
        {
            predictionDictionary = new Dictionary<char, double>();
            for (int j = 2; j < generalMaxSubStringLen; j++)
            {
                if (!charProbabilities[j].ContainsKey(xn.Substring(xn.Length - j))) continue;
                foreach (var move in new List<char> {'R', 'P', 'S', 'W', 'D'})
                {
                    if (!predictionDictionary.ContainsKey(move)) predictionDictionary.Add(move, 0);
                    if (!charProbabilities[j][xn.Substring(xn.Length - j)].ContainsKey(move)) continue;

                    predictionDictionary[move] += charProbabilities[j][xn.Substring(xn.Length - j)][move];
                }
            }
        }
        
        private void GetCharProbsFromFreqs()
        {
            charProbabilities = new Dictionary<int, Dictionary<string, Dictionary<char, double>>>();

            foreach (var stringLenCharFreqStats in charFrequency)
            {
                charProbabilities.Add(stringLenCharFreqStats.Key, new Dictionary<string, Dictionary<char, double>>());

                foreach (var stringCharFreqStats in stringLenCharFreqStats.Value)
                {
                    var stringCharProbStats = new Dictionary<char, double>();
                    var stringChars = stringCharFreqStats.Value.Keys.ToList();
                    var stringCharFreqs = stringCharFreqStats.Value.Values.ToList();

                    for (int i = 0; i < stringChars.Count; i++)
                    {
                        stringCharProbStats.Add(stringChars[i], stringCharFreqs[i] / stringCharFreqs.Sum());
                    }

                    charProbabilities[stringLenCharFreqStats.Key].Add(stringCharFreqStats.Key, stringCharProbStats);
                }
            }
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