using UnityEngine;

namespace GameStates
{
    public class GameBehaviorPlayingEarlyGame : IGameBehavior
    {
        public void Enter()
        {
            Debug.Log("GameBehaviorPlayingEarlyGame");
        }

        public void Update()
        {
            Debug.Log("Earlygame play");
        }

        public void Exit()
        {
            Debug.Log("Earlygame End");
        }
    }
}