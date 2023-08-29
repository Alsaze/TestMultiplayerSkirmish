using UnityEngine;
using DG.Tweening;

namespace Default
{
    public class WindowButtons : MonoBehaviour
    {
        private GameObject _window;

        public void OnClick(GameObject window,GameObject button)
        {
            _window = window;
            if (_window.activeSelf == false)
            {
                button.SetActive(false);
                ShowWindow();
            }
            else
            {
                HideWindow();
                button.SetActive(true);
            }
        }

        private void ShowWindow()
        {
            _window.SetActive(true);
            _window.transform.localScale = Vector3.zero;
            _window.transform.DOScale(Vector3.one, 0.5f);
        }
        private void HideWindow()
        {
            _window.transform.DOScale(Vector3.zero, 0.5f).OnComplete(()
                => _window.SetActive(false));
        }
    }
}
