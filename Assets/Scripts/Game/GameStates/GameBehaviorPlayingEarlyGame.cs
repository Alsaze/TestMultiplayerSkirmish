using Game;
using UnityEngine;

namespace GameStates
{
    public class GameBehaviorPlayingEarlyGame : IGameBehavior
    {
        public void Enter()
        {
            Timer.Instance.StartTimer(true);
        }
        public void Update()
        {
            
        }
        public void Exit()
        {
            Debug.Log("Earlygame End");
        }
    }
}