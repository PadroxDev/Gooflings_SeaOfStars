﻿using Gooflings.Models;
using System;
using System.Collections.Generic;

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
        private MapManager _mapManager;
        private MovementPlayer _movement;

        public GameState State { get; private set; }
        public string CurrentMap { get; private set; }

        public GameState State { get; set; }

        public GameManager()
        {
            _resources = new Resources();
            _inputManager = new InputManager();
            _menu = new Menu(_inputManager);
            _player = new Player();
            _mapManager = new MapManager();
            _movement = new MovementPlayer(_inputManager, _player);

            _nameMap = "Forest";

            State = GameState.Exploring;
            CurrentMap = "Forest";

            //GooflingData rayanData = _resources.GetGooflingData(GooflingType.Radany);
            //rayanData.Level = 12;
            //rayanData.Exp = 100;
            //Goofling rayan = new(rayanData);
            //_player.Party.Members.Add(rayan);

            Serializer.Load(_player);
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
            // menu.Update() // Handle movement with InputManager Redraw
        }

        private void HandleExploring()
        {
            _movement.DoesMove();
            _mapManager.Update(_player, CurrentMap);
            _movement.DoInteraction(_player, "../../../InteractionTxt/" + _nameMap + "-Interaction.txt", _menu, _nameMap, State);
            _player.Draw();
            Renderer.Flush();
        }

        private void HandleMainMenu()
        {

        }

        private void HandleFighting()
        {

        }
    }
}
