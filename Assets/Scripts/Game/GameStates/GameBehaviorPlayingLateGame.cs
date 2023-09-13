using UnityEngine;

namespace GameStates
{
    public class GameBehaviorPlayingLateGame : IGameBehavior
    {
        public void Enter()
        {
            Debug.Log("GameBehaviorPlayingLateGame start");
        }

        public void Update()
        {
            
            Debug.Log("Lategame Update");
        }

        public void Exit()
        {
            Debug.Log("Lategame Exit");
        }
    }
}