using UnityEngine;

namespace GameStates
{
    public class GameBehaviorEndGame : IGameBehavior
    {
        public void Enter()
        {
            Debug.Log("GameBehaviorEndGame start");
        }

        public void Exit()
        {
        }

        public void Update()
        {
            Debug.Log("EndGame");
        }
    }
}