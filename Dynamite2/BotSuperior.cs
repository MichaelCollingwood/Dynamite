﻿﻿﻿﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using BotInterface.Bot;
using BotInterface.Game;

 namespace DynamiteTest
{
    public class BotSuperior : IBot
    {
        public static Dictionary<int, int> stratSuccess { get; set; }
        public static int trailingStrategy { get; set; }

        public Move MakeMove(Gamestate gamestate)
        {
            var XNYN = gamestate.GetRounds();
            return XNYN.Length < 201 ? PseudoRandomMove.GetPseudoRandomMove(XNYN) : F(XNYN);
        }
        
        private static Move F(Round[] xnyn)
        {
            const int generalMaxSubStringLen = 4;
            const int generalEnemyMaxSubStringLen = 4;
            var xn = FormattingClass.FormatXNYN(xnyn)[0];
            var yn = FormattingClass.FormatXNYN(xnyn)[1];
            
            UpdateStratSuccess(xnyn);
            ChooseStrategy();
            
            switch (trailingStrategy)
            {
                case 1:
                {
                    // RESPOND ACCORDING TO THEIR RESPONSE
                    var modelEnemy = new Model1();
                    modelEnemy.TrainDictionary(xnyn, xn, yn, generalMaxSubStringLen);
                    modelEnemy.PredictDictionary(xn, generalMaxSubStringLen);

                    var response = new Response();
                    bool isMyDynamiteFinished = xnyn.Count(xiyi => xiyi.GetP1() == Move.D) == 100;
                    response.GetBestMoveFromPredictionDictionary(modelEnemy.predictionDictionary, isMyDynamiteFinished);
                    response.GetMoveFromString();
                    
                    return response.move;
                }
                case 2:
                {
                    // RESPOND ACCORDING TO THEIR RESPONSE
                    var modelEnemy = new Model1();
                    modelEnemy.TrainDictionary(xnyn, xn, yn, generalMaxSubStringLen);
                    modelEnemy.PredictDictionary(xn, generalMaxSubStringLen);

                    var response = new Response();
                    bool isMyDynamiteFinished = xnyn.Count(xiyi => xiyi.GetP1() == Move.D) == 100;
                    response.GetBestMoveFromPredictionDictionary(modelEnemy.predictionDictionary, isMyDynamiteFinished);
                    response.GetMoveFromString();
                    
                    return response.move;
                }
                case 3:
                {
                    // RESPOND ACCORDING TO THEIR RESPONSE
                    var modelEnemy = new Model1();
                    modelEnemy.TrainDictionary(xnyn, xn, yn, generalMaxSubStringLen);
                    modelEnemy.PredictDictionary(xn, generalMaxSubStringLen);

                    var response = new Response();
                    bool isMyDynamiteFinished = xnyn.Count(xiyi => xiyi.GetP1() == Move.D) == 100;
                    response.GetBestMoveFromPredictionDictionary(modelEnemy.predictionDictionary, isMyDynamiteFinished);
                    response.GetMoveFromString();
                    
                    return response.move;
                }
                case 4:
                {
                    // RESPOND ACCORDING TO THEIR PATTERN
                    var modelEnemy = new Model1();
                    modelEnemy.TrainDictionary(xnyn, yn, yn, generalMaxSubStringLen);
                    modelEnemy.PredictDictionary(yn, generalMaxSubStringLen);

                    var response = new Response();
                    bool isMyDynamiteFinished = xnyn.Count(xiyi => xiyi.GetP1() == Move.D) == 100;
                    response.GetBestMoveFromPredictionDictionary(modelEnemy.predictionDictionary, isMyDynamiteFinished);
                    response.GetMoveFromString();
                    
                    return response.move;
                }
                case 5:
                {
                    // RESPOND ACCORDING TO THEIR PATTERN
                    var modelEnemy = new Model1();
                    modelEnemy.TrainDictionary(xnyn, yn, yn, generalMaxSubStringLen);
                    modelEnemy.PredictDictionary(yn, generalMaxSubStringLen);

                    var response = new Response();
                    bool isMyDynamiteFinished = xnyn.Count(xiyi => xiyi.GetP1() == Move.D) == 100;
                    response.GetBestMoveFromPredictionDictionary(modelEnemy.predictionDictionary, isMyDynamiteFinished);
                    response.GetMoveFromString();
                    
                    return response.move;
                }
                case 6:
                {
                    // RESPOND ACCORDING TO THEIR PATTERN
                    var modelEnemy = new Model1();
                    modelEnemy.TrainDictionary(xnyn, yn, yn, generalMaxSubStringLen);
                    modelEnemy.PredictDictionary(yn, generalMaxSubStringLen);

                    var response = new Response();
                    bool isMyDynamiteFinished = xnyn.Count(xiyi => xiyi.GetP1() == Move.D) == 100;
                    response.GetBestMoveFromPredictionDictionary(modelEnemy.predictionDictionary, isMyDynamiteFinished);
                    response.GetMoveFromString();
                    
                    return response.move;
                }
                case 7:
                {
                    // RESPOND ACCORDING TO HOW I WOULD RESPOND TO MYSELF
                    var modelMe = new Model1();
                    modelMe.TrainDictionary(xnyn, yn, xn, generalEnemyMaxSubStringLen);
                    modelMe.PredictDictionary(yn, generalEnemyMaxSubStringLen);
                    
                    var enemyResponse = new Response();
                    bool isEnemyDynamiteFinished = xnyn.Count(xiyi => xiyi.GetP2() == Move.D) == 100;
                    enemyResponse.GetBestMoveFromPredictionDictionary(modelMe.predictionDictionary, isEnemyDynamiteFinished);
                    
                    var myResponse = new Response();
                    bool isMyDynamiteFinished = xnyn.Count(xiyi => xiyi.GetP1() == Move.D) == 100;
                    myResponse.GetBestMoveFromPrediction(enemyResponse.moveString, isMyDynamiteFinished);
                    myResponse.GetMoveFromString();
                    
                    return myResponse.move;
                }
                case 8:
                {
                    // RESPOND ACCORDING TO HOW I WOULD RESPOND TO MYSELF
                    var modelMe = new Model1();
                    modelMe.TrainDictionary(xnyn, yn, xn, generalEnemyMaxSubStringLen);
                    modelMe.PredictDictionary(yn, generalEnemyMaxSubStringLen);
                    
                    var enemyResponse = new Response();
                    bool isEnemyDynamiteFinished = xnyn.Count(xiyi => xiyi.GetP2() == Move.D) == 100;
                    enemyResponse.GetBestMoveFromPredictionDictionary(modelMe.predictionDictionary, isEnemyDynamiteFinished);
                    
                    var myResponse = new Response();
                    bool isMyDynamiteFinished = xnyn.Count(xiyi => xiyi.GetP1() == Move.D) == 100;
                    myResponse.GetBestMoveFromPrediction(enemyResponse.moveString, isMyDynamiteFinished);
                    myResponse.GetMoveFromString();
                    
                    return myResponse.move;
                }
                case 9:
                {
                    // RESPOND ACCORDING TO HOW I WOULD RESPOND TO MYSELF
                    var modelMe = new Model1();
                    modelMe.TrainDictionary(xnyn, yn, xn, generalEnemyMaxSubStringLen);
                    modelMe.PredictDictionary(yn, generalEnemyMaxSubStringLen);
                    
                    var enemyResponse = new Response();
                    bool isEnemyDynamiteFinished = xnyn.Count(xiyi => xiyi.GetP2() == Move.D) == 100;
                    enemyResponse.GetBestMoveFromPredictionDictionary(modelMe.predictionDictionary, isEnemyDynamiteFinished);
                    
                    var myResponse = new Response();
                    bool isMyDynamiteFinished = xnyn.Count(xiyi => xiyi.GetP1() == Move.D) == 100;
                    myResponse.GetBestMoveFromPrediction(enemyResponse.moveString, isMyDynamiteFinished);
                    myResponse.GetMoveFromString();
                    
                    return myResponse.move;
                }
                case 10:
                {
                    return PseudoRandomMove.GetPseudoRandomMove(xnyn);
                }
                default:
                    return Move.D;
            }
        }

        public static void UpdateStratSuccess(Round[] xnyn)
        {
            if (trailingStrategy != 0)
            {
                if (stratSuccess == null)
                {
                    stratSuccess = new Dictionary<int, int>{{1,100},{2,100},{3,100},{4,100},{5,100},{6,100},{7,100},{8,100},{9,100},{10,100}};
                }
                
                stratSuccess[trailingStrategy] += Scoring.GetScore(xnyn[xnyn.Length - 1].GetP1(), xnyn[xnyn.Length - 1].GetP2());
            }
        }

        public static void ChooseStrategy()
        {
            if (stratSuccess == null)
            {
                trailingStrategy = 1;
            }
            else
            {
                trailingStrategy = stratSuccess.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            }
        }
    }
}