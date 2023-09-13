using Game;
using UnityEngine;

namespace GameStates
{
    public class GameBehaviorPlayingEarlyGame : IGameBehavior
    {
        public void Enter()
        {
            Timer.Instance.StartTimer();
            
            Debug.Log("GameBehaviorPlayingEarlyGame");
        }
        public void Update()
        {
            Debug.Log("EarlyGame Update");
        }
        public void Exit()
        {
            Debug.Log("Earlygame Exit");
        }
    }
}