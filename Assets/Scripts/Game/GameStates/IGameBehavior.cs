using System;
using UnityEngine;

namespace GameStates
{
    public interface IGameBehavior
    {
        public void Enter();
        public void Exit();
        public void Update();

    }
}