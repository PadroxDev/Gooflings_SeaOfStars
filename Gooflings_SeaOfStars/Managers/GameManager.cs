using Gooflings.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gooflings
{
    public enum GameState
    {
        TitleMenu,
        Exploring,
        MainMenu,
        Fighting
    }

    public class GameManager
    {
        private Resources _resources;
        private InputManager _inputManager;
        private Menu _menu;
        private Player _player;
        private MovementPlayer _movement;

        public GameState State { get; private set; }
        private int _stateMenu;

        public GameManager()
        {
            _resources = new Resources();
            _inputManager = new InputManager();
            _menu = new Menu(_inputManager);
            _player = new Player();
            _movement = new MovementPlayer(_inputManager, _player);


            State = GameState.TitleMenu;

            //GooflingData rayanData = _resources.GetGooflingData(GooflingType.Radany);
            //rayanData.Level = 12;
            //rayanData.Exp = 100;
            //Goofling rayan = new(rayanData);
            //_player.Party.Members.Add(rayan);

            Serializer.Load(_player);
            _menu.DrawBattleMenu(_player.Party.Members,);
        }

        public void Update()
        {
            _inputManager.Update();

            if(_inputManager.GetKeyDown(ConsoleKey.M))
            {
                Serializer.Save(_player);
            }

            switch (State)
            {
                case GameState.TitleMenu:
                    HandleTitleMenu();
                    break;
                case GameState.Exploring:
                    HandleExploring();
                    break;
                case GameState.MainMenu:
                    HandleMainMenu();
                    break;
                case GameState.Fighting:
                    HandleFighting();
                    break;
            }
        }

        private void HandleTitleMenu()
        {
            _stateMenu = 0;
            _menu.Update(_stateMenu);
        }

        private void HandleExploring()
        {
            _movement.DoesMove();
            _player.Draw();
            Renderer.Flush();
        }

        private void HandleMainMenu()
        {
            _stateMenu = 1;
            _menu.Update(_stateMenu);
        }

        private void HandleFighting()
        {
            _stateMenu = 6;
            _menu.Update(_stateMenu);
        }
    }
}
