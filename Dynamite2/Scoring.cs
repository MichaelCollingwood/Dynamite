﻿using System.Collections.Generic;
using BotInterface.Game;

namespace DynamiteTest
{
    public class Scoring
    {
        private static Dictionary<Move, Dictionary<Move, int>> outcomes = new Dictionary<Move, Dictionary<Move, int>>
        {
            {Move.R, new Dictionary<Move, int> {{Move.R, 0}, {Move.P, -1}, {Move.S, 1}, {Move.D, -1}, {Move.W, 1}}},
            {Move.P, new Dictionary<Move, int> {{Move.R, 1}, {Move.P, 0}, {Move.S, -1}, {Move.D, -1}, {Move.W, 1}}},
            {Move.S, new Dictionary<Move, int> {{Move.R, -1}, {Move.P, 1}, {Move.S, 0}, {Move.D, -1}, {Move.W, 1}}},
            {Move.D, new Dictionary<Move, int> {{Move.R, 1}, {Move.P, 1}, {Move.S, 1}, {Move.D, 0}, {Move.W, -1}}},
            {Move.W, new Dictionary<Move, int> {{Move.R, -1}, {Move.P, -1}, {Move.S, -1}, {Move.D, 1}, {Move.W, 0}}}
        };
        public static int GetScore(Move m1, Move m2)
        {
            return outcomes[m1][m2];
        }
    }
}