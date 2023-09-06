using UnityEngine;

namespace GameStates
{
    public class GameBehaviorPlayingLateGame : IGameBehavior
    {
        public void Enter()
        {
            Debug.Log("GameBehaviorPlayingLateGame start");
        }

        public void Exit()
        {
        }

        public void Update()
        {
            Debug.Log("Lategame play");
        }
    }
}