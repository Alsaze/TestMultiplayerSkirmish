using UnityEngine;

namespace GameStates
{
    public class GameBehaviorWaitingPlayers : IGameBehavior
    {
        public void Enter()
        {
            Debug.Log("GameBehaviorWaitingPlayers Start");
        }

        public void Exit()
        {
        }

        public void Update()
        {
            Debug.Log("WaitPlayer");
        }
    }
}