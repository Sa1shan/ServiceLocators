using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.GamePlay
{
    public class MainView : MonoBehaviour
    {
        [SerializeField] private Button openButton;

        public event Action OnOpen;

        private void Awake()
        {
            if (openButton != null)
            {
                openButton.onClick.AddListener(HandleOpenClick);
            }
        }

        private void OnDestroy()
        {
            if (openButton != null)
            {
                openButton.onClick.RemoveListener(HandleOpenClick);
            }
        }

        private void HandleOpenClick()
        {
            OnOpen?.Invoke();
        }

        public void SetOpenInteractable(bool value)
        {
            if (openButton != null)
            {
                openButton.interactable = value;
            }
        }
    }
}