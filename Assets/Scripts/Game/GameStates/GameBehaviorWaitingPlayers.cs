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
            Debug.Log("WaitingPlayers Update");
        }

        public void Exit()
        {
            Debug.Log("WaitingPlayers Exit");
        }
    }
}