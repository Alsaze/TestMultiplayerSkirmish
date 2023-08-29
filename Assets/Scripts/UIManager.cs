using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Default
{
    public class UIManager : MonoBehaviour
    {
        private WindowButtons _windowButtons;

        [SerializeField] private GameObject panelCreateRoom;
        [SerializeField] private GameObject panelCreateButton;
        [SerializeField] private GameObject panelEnterCode;
        [SerializeField] private GameObject enterCodeButton;

        private void Awake()
        {
            _windowButtons = GetComponent<WindowButtons>();
        }

        public void CreateRoom()
        {
            _windowButtons.OnClick(panelCreateRoom, enterCodeButton);
        }

        public void EnterCode()
        {
            _windowButtons.OnClick(panelEnterCode, panelCreateButton);
        }
    }
}
