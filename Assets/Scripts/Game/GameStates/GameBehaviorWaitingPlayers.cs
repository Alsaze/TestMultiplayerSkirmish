using UnityEngine;

namespace GameStates
{
    public class GameBehaviorWaitingPlayers : IGameBehavior
    {
        public void Enter()
        {
            Debug.Log("GameBehaviorWaitingPlayers Start");
        }

        public void Update()
        {
            Debug.Log("WaitPlayer");
        }

        public void Exit()
        {
            Debug.Log("3,2,1");
        }
    }
}