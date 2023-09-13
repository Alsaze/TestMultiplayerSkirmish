using System.Collections;
using UnityEngine;
using GameStates;
using Mirror;
using TMPro;

namespace Game
{
    public class Timer : MonoBehaviour
    {
        public static Timer Instance;
        [SerializeField] private TextMeshProUGUI text;
        
        private float _timerLateGame = 5f;//20f

        private float _currentTime = 25f;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        [Server]
        public void StartTimer()
        {
            StartCoroutine("TimerGame");
        }

        [Server]
        IEnumerator TimerGame()
        {
            while (_currentTime >= _timerLateGame)
            {
                yield return new WaitForSeconds(1);

                _currentTime--;
            }

            GameStateManager.Instance.SetBehaviorPlayingLateGame();

            while (_currentTime >= 0)
            {
                yield return new WaitForSeconds(1);

                _currentTime--;
            }

            GameStateManager.Instance.SetBehaviorEndGame();

        }

        [Client]
        private void Update()
        {
            text.text = FormatTime(_currentTime);
        }

        [Client]
        private string FormatTime(float time)
        {
            int minutes = Mathf.FloorToInt(time / 60f);
            int seconds = Mathf.FloorToInt(time % 60f);
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
