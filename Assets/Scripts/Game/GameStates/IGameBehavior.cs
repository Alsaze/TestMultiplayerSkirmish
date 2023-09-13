using System;
using Mirror;
using UnityEngine;

namespace GameStates
{
    public interface IGameBehavior
    { 
        [Server]
        public void Enter();
        [Server]
        public void Update();
        [Server]
        public void Exit();
    }
}
