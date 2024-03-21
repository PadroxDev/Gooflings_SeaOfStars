using System;
using System.Collections.Generic;

namespace Gooflings.Battle
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

    public enum Action
    {
        Swap,
        Item,
        Move
    }

    public class BattleManager
    {
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

        void HandleSpawnGooflings()
        {

        }

        void HandleWaitForAction()
        {

        }

        void HandleEvaluateActionOrder()
        {

        }

        void HandleExecuteActions()
        {

        }

        void HandleSwapGoofling()
        {

        }

        void HandleCleanup()
        {

        }
    }
}
