using Gooflings.Models;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace Gooflings
{
    public enum GameState
    {
        TitleMenu,
        Exploring,
        MainMenu,
        Fighting,
        GooflingMenu,
        BagMenu
    }

    public class GameManager
    {
        private Resources _resources;
        private InputManager _inputManager;
        private Menu _menu;
        private Player _player;
        private MapManager _mapManager;
        private MovementPlayer _movement;
        private BattleManager _battleManager;

        private Trainer _trainer;
        public GameState State;
        public string CurrentMap { get; private set; }
        private int _stateMenu;

        public GameManager()
        {
            _resources = new Resources();
            _inputManager = new InputManager();
            _menu = new Menu(_inputManager);
            _player = new Player();
            _mapManager = new MapManager();
            _movement = new MovementPlayer(_inputManager, _player);
            TrainerData AntoineData = Resources.Instance.GetTrainerData(TrainerType.Antoine);
            _trainer = new Trainer(AntoineData);
            State = GameState.TitleMenu;
            _battleManager = null;

            CurrentMap = "Forest";

            GooflingData rayanData = _resources.GetGooflingData(GooflingType.Radany);
            rayanData.Level = 12;
            rayanData.Exp = 100;
            Goofling rayan = new(rayanData);
            _player.Party.Members.Add(rayan);
            _player.Party.Members.Add(rayan);
            _player.Party.Members.Add(rayan);
            _player.Party.Members.Add(rayan);

            Serializer.Load(_player);
            //_menu.DrawBattleMenu(_player.Party.Members, _trainer.Party.Members[0]);
            _menu.DrawTitleMenu();
            
        }

        public void Update()
        {
            _inputManager.Update();

            
            switch (State)
            {
                case GameState.TitleMenu:
                    HandleTitleMenu();
                    break;
                case GameState.Exploring:
                    HandleExploring();
                    if (State == GameState.Exploring && _inputManager.GetKeyDown(ConsoleKey.Spacebar))
                    {
                        HandleMainMenu();
                        State = GameState.MainMenu;
                    }
                    break;
                case GameState.MainMenu:
                    HandleMainMenu();
                    break;
                case GameState.Fighting:
                    HandleFighting();
                    break;
                case GameState.GooflingMenu:
                    HandleGooflingMenu();
                    break;
                case GameState.BagMenu:
                    HandleBagMenu();
                    break;
            }
        }

        private void HandleTitleMenu()
        {
            _stateMenu = 0;
            _menu.Update(_stateMenu, _player, null, ref State);
        }
        private void HandleGooflingMenu()
        {
            _stateMenu = 2;
            _menu.Update(_stateMenu, _player, null, ref State);
        }
        private void HandleBagMenu()
        {
            _stateMenu = 4;
            _menu.Update(_stateMenu, _player, null, ref State);
        }
        private void HandleExploring()
        {
            _mapManager.Update(_player, CurrentMap);
            CurrentMap = _movement.DoInteraction("../../../InteractionTxt/" + CurrentMap + "-Interaction.txt", _menu, CurrentMap,ref State);
            //_movement.DoesMove();
            _player.Draw();
            Renderer.Flush();
        }

        private void HandleMainMenu()
        {
            _stateMenu = 1;
            _menu.Update(_stateMenu, _player , null, ref State);
        }

        private void HandleFighting()
        {
            
            if (_battleManager is null) // Start an encounter
            {
                GooflingData encounterData = Resources.Instance.GetRandomGooflingData();
                encounterData.Level = Helpers.Rand.Next(10, 30);
                Goofling encounter = new Goofling(encounterData);
                _battleManager = new(_player, encounter);
            }
            _stateMenu = 6;
            _menu.Update(_stateMenu, _player, _battleManager, ref State);
        }
    }
}
