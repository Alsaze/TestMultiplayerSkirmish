using UnityEngine;

namespace GameStates
{
    public class GameBehaviorPlayingEarlyGame : IGameBehavior
    {
        public void Enter()
        {
            Debug.Log("GameBehaviorPlayingEarlyGame");
        }

        public void Exit()
        {
        }

        public void Update()
        {
            Debug.Log("Earlygame play");
        }
    }
}