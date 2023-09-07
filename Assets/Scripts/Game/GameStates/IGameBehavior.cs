using System;
using UnityEngine;

namespace GameStates
{
    public interface IGameBehavior
    { 
        public void Enter();
        public void Update();
        public void Exit();
    }
}
