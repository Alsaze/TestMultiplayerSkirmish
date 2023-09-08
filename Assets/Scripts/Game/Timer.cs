using System;
using UnityEngine;
using GameStates;

namespace Game
{
    public class Timer : MonoBehaviour
    {
        public static Timer Instance;
        private bool _isTimerRunning = false;

        private float _timerGameDuration = 60f; // Timer
        private float _timerLateGameDuration = 20f; //When start LateGame

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void StartTimer(bool start)
        {
            _isTimerRunning = start;
        }

        private void Update()
        {
            if (_isTimerRunning)
            {
                _timerGameDuration -= Time.deltaTime;

                if (_timerGameDuration <= 0)
                {
                    GameStateManager.Instance.SetBehaviorEndGame();
                    return;
                }
                
                if (_timerGameDuration <= _timerLateGameDuration)
                {
                    GameStateManager.Instance.SetBehaviorPlayingLateGame();
                }
            }
        }
    }
}