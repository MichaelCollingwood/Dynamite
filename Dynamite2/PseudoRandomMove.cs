﻿﻿using System;
using System.Linq;
using BotInterface.Game;

namespace DynamiteTest
{
    public class PseudoRandomMove
    {
        private static readonly Random random = new Random(); 
        private static readonly object syncLock = new object();
        private static double RandomNumber()
        {
            lock(syncLock) 
            { 
                return random.NextDouble();
            }
        }
        
        public static BotInterface.Game.Move GetPseudoRandomMove(Round[] xnyn)
        {
            while (true){
                var randomDouble = RandomNumber();
                double[] cumProbDensity = {0, 0.1667, 0.3333, 0.5, 0.6667, 1};

                if (randomDouble >= cumProbDensity[0] && randomDouble < cumProbDensity[1])
                {
                    return Move.R;
                }

                if (randomDouble >= cumProbDensity[1] && randomDouble < cumProbDensity[2])
                {
                    return Move.P;
                }

                if (randomDouble >= cumProbDensity[2] && randomDouble < cumProbDensity[3])
                {
                    return Move.S;
                }

                if (randomDouble >= cumProbDensity[3] && randomDouble < cumProbDensity[4])
                {
                    return Move.W;
                }

                if (randomDouble >= cumProbDensity[4] && randomDouble < cumProbDensity[5] &&
                    xnyn.Count(x => x.GetP1() == Move.D) < 100)
                {
                    return Move.D;
                }
            }
        }
    }
}