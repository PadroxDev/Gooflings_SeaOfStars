using System;
using System.Collections.Generic;

namespace Gooflings
{
    public enum BattleState
    {
        SpawnGooflings,
        WaitForAction,
        EvaluateActionOrder,
        ExecuteActions,
        SwapGoofling,
        Cleanup,
    }

    public enum zeze
    {
        Swap,
        Item,
        Move
    }

    public class BattleManager
    {

        public Goofling PlayerGoofling;
        public Goofling EnemyGoofling;

        public BattleState State { get; private set; }

        public Player Player { get; private set; }
        public Trainer Contender { get; private set; }

        public BattleManager(Player plr, Trainer tnr)
        {
            State = BattleState.SpawnGooflings;

            Player = plr;
            Contender = tnr;
        }

        ~BattleManager()
        {}

        void Update()
        {
            switch (State)  
            {
                case BattleState.SpawnGooflings:
                    break;
                case BattleState.WaitForAction:
                    break;
                case BattleState.EvaluateActionOrder:
                    break;
                case BattleState.ExecuteActions:
                    break;
                case BattleState.SwapGoofling:
                    break;
                case BattleState.Cleanup:
                    break;
            }
        }

        void HandleSpawnGooflings(Goofling goofling)
        {
            PlayerGoofling = Player.Party.Members[0];
            EnemyGoofling = goofling;
        }

        void HandleWaitForAction()
        {

        }

        void HandleEvaluateActionOrder(string Playermove)
        {
            switch (Playermove)
            {
                case "attack":
                    if (PlayerGoofling.Speed > EnemyGoofling.Speed)
                    {
                        HandleExecuteActions("player");
                        break;
                    }
                    if (PlayerGoofling.Speed < EnemyGoofling.Speed)
                    {
                        HandleExecuteActions("enemy");
                        break;
                    }
                    else // both SpAtk are the same
                    {
                        HandleExecuteActions("player");
                        break;
                    }
                case "chnageOfGoofling":
                    HandleExecuteActions("player");
                    break;
                case "other":
                    HandleExecuteActions("enemy");
                    break;
            } 
        }

        void HandleExecuteActions(string FirstPlayer)
        {
            switch(FirstPlayer)
            {
                case "player":
                    // player move
                    // enemy move
                    break;
                case "enemy":
                    // enemy move
                    // player move
                    break;
            }
        }

        void HandleSwapGoofling()
        {

        }

        void HandleCleanup()
        {

        }
    }
}
