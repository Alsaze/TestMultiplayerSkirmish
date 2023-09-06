using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameStates
{
    public class GameStateManager : MonoBehaviour
    {
        private Dictionary<Type, IGameBehavior> _behaviorsMap;
        private IGameBehavior _behaviorCurrent;

        private void Start()
        {
            InitBehaviors();
            SetBehaviorByDefault();
        }

        private void InitBehaviors()
        {
            _behaviorsMap = new Dictionary<Type, IGameBehavior>();

            _behaviorsMap[typeof(GameBehaviorWaitingPlayers)] = new GameBehaviorWaitingPlayers();
            _behaviorsMap[typeof(GameBehaviorPlayingEarlyGame)] = new GameBehaviorPlayingEarlyGame();
            _behaviorsMap[typeof(GameBehaviorPlayingLateGame)] = new GameBehaviorPlayingLateGame();
            _behaviorsMap[typeof(GameBehaviorEndGame)] = new GameBehaviorEndGame();
        }

        private void SetBehavior(IGameBehavior newBehavior)
        {
            if (_behaviorCurrent != null)
            {
                _behaviorCurrent.Exit();
            }

            _behaviorCurrent = newBehavior;
            _behaviorCurrent.Enter();
        }

        private void SetBehaviorByDefault()
        {
            SetBehaviorWaitingPlayers();
        }

        private IGameBehavior GetBehavior<T>() where T : IGameBehavior
        {
            var type = typeof(T);
            return _behaviorsMap[type];
        }

        private void Update()
        {
            if (_behaviorCurrent != null)
            {
                _behaviorCurrent.Update();
            }
        }

        public void SetBehaviorWaitingPlayers()
        {
            var behavior = GetBehavior<GameBehaviorWaitingPlayers>();
            SetBehavior(behavior);
        }

        public void SetBehaviorPlayingEarlyGame()
        {
            var behavior = GetBehavior<GameBehaviorPlayingEarlyGame>();
            SetBehavior(behavior);
        }

        public void SetBehaviorPlayingLateGame()
        {
            var behavior = GetBehavior<GameBehaviorPlayingLateGame>();
            SetBehavior(behavior);
        }

        public void SetBehaviorEndGame()
        {
            var behavior = GetBehavior<GameBehaviorEndGame>();
            SetBehavior(behavior);
        }
    }
}
