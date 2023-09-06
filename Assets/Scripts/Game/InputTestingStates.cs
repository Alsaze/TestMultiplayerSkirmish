using GameStates;
using UnityEngine;

namespace Game
{
    public class InputTestingStates : MonoBehaviour
    {
        [SerializeField] private GameStateManager gameStateManager;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                gameStateManager.SetBehaviorWaitingPlayers();
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                gameStateManager.SetBehaviorPlayingEarlyGame();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                gameStateManager.SetBehaviorPlayingLateGame();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                gameStateManager.SetBehaviorEndGame();
            }
        }
    }
}