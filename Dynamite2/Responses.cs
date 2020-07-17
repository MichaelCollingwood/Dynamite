﻿﻿﻿﻿﻿﻿using System;
 using System.Collections.Generic;
using System.Linq;
using BotInterface.Game;

namespace DynamiteTest
{
    public class Response
    {
        public char moveString { get; set; }
        public Move move { get; set; }

        public void GetBestMoveFromPredictionDictionary(Dictionary<char, double> predictionDictionary, bool isDynamiteFinished)
        {

            // EXPECTED VALUES
            var expectedValOfMyR = - predictionDictionary['P'] + predictionDictionary['S'] + predictionDictionary['W'] - predictionDictionary['D'];
            var expectedValOfMyP = predictionDictionary['R'] - predictionDictionary['S'] + predictionDictionary['W'] - predictionDictionary['D'];
            var expectedValOfMyS = - predictionDictionary['R'] + predictionDictionary['P'] + predictionDictionary['W'] - predictionDictionary['D'];
            var expectedValOfMyW = - predictionDictionary['R'] - predictionDictionary['P'] - predictionDictionary['S'] + predictionDictionary['D'];
            var expectedValOfMyD = predictionDictionary['R'] + predictionDictionary['P'] + predictionDictionary['S'] - predictionDictionary['W'];

            var expectedVals = new List<double> { expectedValOfMyR, expectedValOfMyP, expectedValOfMyS, expectedValOfMyW, expectedValOfMyD };
            var charList = new List<char> {'R','P','S','W','D'};

            if (isDynamiteFinished)
            {
                expectedVals.RemoveAt(expectedVals.Count - 1);
                charList.RemoveAt(charList.Count - 1);
            }

            double maxVal = expectedVals.Max();
            int index = expectedVals.IndexOf(maxVal);

            moveString = charList[index];
        }
        
        public void GetBestMoveFromPrediction(char enemyMove, bool isDynamiteFinished)
        {
            var random = new Random();
            var winningList = new List<char>();
            
            switch (enemyMove)
            {
                case 'R':
                    winningList = isDynamiteFinished? new List<char>{'P'} : new List<char>{'P','D'};
                    moveString = winningList[random.Next(winningList.Count)];
                    break;
                case 'P':
                    winningList = isDynamiteFinished? new List<char>{'S'} : new List<char>{'S','D'};
                    moveString = winningList[random.Next(winningList.Count)];
                    break;
                case 'S':
                    winningList = isDynamiteFinished? new List<char>{'R'} : new List<char>{'R','D'};
                    moveString = winningList[random.Next(winningList.Count)];
                    break;
                case 'W':
                    winningList = new List<char> {'R','P','S'};
                    moveString = winningList[random.Next(winningList.Count)];
                    break;
                case 'D':
                    winningList = new List<char> {'W'};
                    moveString = winningList[random.Next(winningList.Count)];
                    break;
            }
        }
        
        public void GetMoveFromString()
        {
            switch (moveString)
            {
                case 'R':
                    move = BotInterface.Game.Move.R;
                    return;
                case 'P':
                    move = BotInterface.Game.Move.P;
                    return;
                case 'S':
                    move = BotInterface.Game.Move.S;
                    return;
                case 'W':
                    move = BotInterface.Game.Move.W;
                    return;
                case 'D':
                    move = BotInterface.Game.Move.D;
                    return;
            }
        }

        /*
        public void PrintMove()
        {
            Console.WriteLine("Move Chosen");
            Console.WriteLine(move);
        }
        */
    }
}