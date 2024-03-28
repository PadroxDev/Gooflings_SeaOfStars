using Gooflings.Moves;
using System;
using System.Collections.Generic;
using System.Xml;

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

        Goofling PlayerGoofling;
        Goofling EnemyGoofling;
        Move PlayerMove;
        Move EnemyMove;

        bool PlayerTeamState;
        bool EnemyTeamState;

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
            HandleWaitForAction();
        }

        void HandleWaitForAction()
        {
            // choose with battle menu
            // playermove = what player choose
            // if attack : PlayerMove = attack
            // HandleEvaluateActionOrder(playermove)
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
                    else // both Speed are the same
                    {
                        HandleExecuteActions("player");
                        break;
                    }
                case "chnageOfGoofling":
                    HandleSwapGoofling("alive", PlayerGoofling);
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
                    
                    EnemyGoofling.TakeDamage(Helpers.CalculateDamageToDeal(PlayerGoofling, EnemyGoofling, PlayerMove));
                    // enemy move
                    PlayerGoofling.TakeDamage(Helpers.CalculateDamageToDeal(EnemyGoofling, PlayerGoofling, EnemyMove));
                    break;
                case "enemy":
                    // enemy move
                    PlayerGoofling.TakeDamage(Helpers.CalculateDamageToDeal(EnemyGoofling, PlayerGoofling, EnemyMove));
                    // player move
                    EnemyGoofling.TakeDamage(Helpers.CalculateDamageToDeal(PlayerGoofling, EnemyGoofling, PlayerMove));
                    break;
                case "onlyEnemy":
                    // enemy move
                    PlayerGoofling.TakeDamage(Helpers.CalculateDamageToDeal(EnemyGoofling, PlayerGoofling, EnemyMove));
                    break;
            }
            if(PlayerGoofling.HP == 0)
            {
                HandleSwapGoofling("dead", PlayerGoofling);
            }
            if(EnemyGoofling.HP == 0)
            {
                // gain xp pour le pokemon
                HandleSwapGoofling("dead", EnemyGoofling);
            }
            else
            {
                HandleWaitForAction();
            }
        }

        void HandleSwapGoofling(string GooflingState, Goofling swapedGoofling)
        {
            switch (GooflingState)
            {
                case "alive":
                    // menu de choix pokemon
                    swapedGoofling = swapedGoofling;// pokemon choisie
                    HandleExecuteActions("onlyEnemy");
                    break;
                case "dead":
                    PlayerTeamState = false;
                    EnemyTeamState = false;
                    foreach (Goofling goofling in Player.Party.Members)
                    {
                        if (goofling.HP != 0)
                        {
                            PlayerTeamState = true;
                        }
                    }
                    foreach (Goofling goofling in Contender.Party.Members)
                    {
                        if (goofling.HP != 0)
                        {
                            EnemyTeamState = true;
                        }
                    }
                    if (PlayerTeamState && EnemyTeamState)
                    {
                        // menu de choix pokemon
                        swapedGoofling = swapedGoofling;// pokemon choisie
                        HandleWaitForAction();
                        break;
                    }
                    else
                    {
                        HandleCleanup();
                        break;
                    }
                    
            }
        }

        void HandleCleanup()
        {
            if (PlayerTeamState && !EnemyTeamState)
            {
                Console.WriteLine("you win");
                //ferme le menu de combats
            }
            else if (!PlayerTeamState && EnemyTeamState)
            {
                Console.WriteLine("you loose");
                //ferme le menu de combats
            }
            else if (!PlayerTeamState && !EnemyTeamState)
            {
                Console.WriteLine("tie");
                //ferme le menu de combats
            }
        }
    }
}
