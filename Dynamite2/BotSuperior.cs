﻿﻿﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using BotInterface.Bot;
using BotInterface.Game;

 namespace DynamiteTest
{
    public class BotSuperior : IBot
    {
        public Move MakeMove(Gamestate gamestate)
        {
            var XNYN = gamestate.GetRounds();
            return XNYN.Length < 201 ? PseudoRandomMove.GetPseudoRandomMove(XNYN) : F(XNYN);
        }
        
        private static Move F(Round[] xnyn)
        {
            const int generalMaxSubStringLen = 10;
            var strategy = 1;
            
            var xn = FormattingClass.FormatXNYN(xnyn)[0];
            var yn = FormattingClass.FormatXNYN(xnyn)[1];

            var modelEnemy = new Model1();
            modelEnemy.TrainDictionary(xnyn, xn, yn, generalMaxSubStringLen);
            modelEnemy.PredictDictionary(xn, generalMaxSubStringLen);
            bool isMyDynamiteFinished = xnyn.Count(xiyi => xiyi.GetP1() == Move.D) == 100;
            
            switch (strategy)
            {
                case 1:
                {
                    // RESPOND ACCORDING TO THEIR RESPONSE
                    var response = new Response();
                    response.GetBestMoveFromPredictionDictionary(modelEnemy.predictionDictionary, isMyDynamiteFinished);
                    response.GetMoveFromString();
                
                    return response.move;
                }
                case 2:
                {
                    // RESPOND ACCORDING TO HOW I WOULD RESPOND TO MYSELF
                    var modelMe = new Model1();
                    modelMe.TrainDictionary(xnyn, yn, xn, generalMaxSubStringLen);
                    modelMe.PredictDictionary(yn, generalMaxSubStringLen);
                    bool isEnemyDynamiteFinished = xnyn.Count(xiyi => xiyi.GetP2() == Move.D) == 100;
                
                    var enemyResponse = new Response();
                    enemyResponse.GetBestMoveFromPredictionDictionary(modelMe.predictionDictionary, isEnemyDynamiteFinished);
                
                    var myResponse = new Response();
                    myResponse.GetBestMoveFromPrediction(enemyResponse.moveString, isMyDynamiteFinished);
                    myResponse.GetMoveFromString();
                
                    return myResponse.move;
                }
                default:
                    return Move.D;
            }
        }
    }
}