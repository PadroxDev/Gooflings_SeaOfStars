using Gooflings.Moves;
using System;
using System.Collections.Generic;
using System.Resources;
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

        public Goofling PlayerGoofling;
        public Goofling EnemyGoofling;
        public Move PlayerMove;
        public Move EnemyMove;
        public bool PlayerTeamState;
        public bool EnemyTeamState;

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

        public void HandleSpawnGooflings(Resources resources)
        {
            PlayerGoofling = Player.Party.Members[0];
            EnemyGoofling = Contender.Party.Members[0];
            HandleWaitForAction(resources.GetMove(MoveType.Croustifesses), resources.GetMove(MoveType.Croustifesses));
        }

        void HandleWaitForAction(Move Playermove, Move Enemymove)
        {
            Thread.Sleep(2000);
            PlayerMove = Playermove;
            EnemyMove = Enemymove;
            HandleEvaluateActionOrder("attack");
        }

        void HandleEvaluateActionOrder(string Playermove)
        {
            switch (Playermove)
            {
                case "attack":
                    if (PlayerGoofling.Speed > EnemyGoofling.Speed)
                    {
                        Console.WriteLine("player turn");
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
                case "changeOfGoofling":
                    HandleSwapGoofling("alive", PlayerGoofling);
                    break;
                case "other":
                    //Menu.DrawBagMenu();
                    //use items
                    HandleExecuteActions("enemy");
                    break;
            } 
        }

        void HandleExecuteActions(string FirstPlayer)
        {
            switch(FirstPlayer)
            {
                case "player":
                    if(PlayerGoofling.Mana > 0)
                    {
                        // player move
                        EnemyGoofling.TakeDamage(Helpers.CalculateDamageToDeal(PlayerGoofling, EnemyGoofling, PlayerMove));
                        PlayerGoofling.Mana -= PlayerMove.ManaCost;
                    }
                    else
                    {
                        Console.WriteLine("Not enough mana");
                    }
                    // enemy move
                    PlayerGoofling.TakeDamage(Helpers.CalculateDamageToDeal(EnemyGoofling, PlayerGoofling, EnemyMove));
                    EnemyGoofling.Mana -= EnemyMove.ManaCost;
                    break;
                case "enemy":
                    // enemy move
                    PlayerGoofling.TakeDamage(Helpers.CalculateDamageToDeal(EnemyGoofling, PlayerGoofling, EnemyMove));
                    EnemyGoofling.Mana -= EnemyMove.ManaCost;
                    // player move
                    EnemyGoofling.TakeDamage(Helpers.CalculateDamageToDeal(PlayerGoofling, EnemyGoofling, PlayerMove));
                    PlayerGoofling.Mana -= PlayerMove.ManaCost;
                    break;
                case "onlyEnemy":
                    // enemy move
                    PlayerGoofling.TakeDamage(Helpers.CalculateDamageToDeal(EnemyGoofling, PlayerGoofling, EnemyMove));
                    EnemyGoofling.Mana -= EnemyMove.ManaCost;
                    break;
            }
            if(PlayerGoofling.HP == 0)
            {
                Console.WriteLine("player goofling dead");
                HandleSwapGoofling("dead", PlayerGoofling);
            }
            else if(EnemyGoofling.HP == 0)
            {
                Console.WriteLine("ennemy goofling dead");
                PlayerGoofling.GainExperience(1000);
                HandleSwapGoofling("dead", EnemyGoofling);
            }
            else
            {
                Console.WriteLine("next turn");
                HandleWaitForAction(PlayerMove, EnemyMove);
            }
        }

        void HandleSwapGoofling(string GooflingState, Goofling swapedGoofling)
        {
            switch (GooflingState)
            {
                case "alive":
                    // menu de choix pokemon 
                    //Menu.DrawTeamMenu(Player.Party);

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
                            PlayerGoofling = Player.Party.Members[1];
                        }
                    }
                    foreach (Goofling goofling in Contender.Party.Members)
                    {
                        if (goofling.HP != 0)
                        {
                            EnemyTeamState = true;
                            EnemyGoofling = Contender.Party.Members[1];
                        }
                    }
                    if (PlayerTeamState && EnemyTeamState)
                    {
                        // menu de choix pokemon
                        EnemyGoofling.Mana += 20;
                        PlayerGoofling.Mana += 20;
                        HandleWaitForAction(PlayerMove ,EnemyMove);
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
                foreach (Goofling goofling in Player.Party.Members)
                {
                    goofling.GainExperience(1000);
                }
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
