using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.GamePlay
{
    public class PanelView : MonoBehaviour
    {
        [SerializeField] private Button closeButton;
        [SerializeField] private Button collectButton;
        [SerializeField] private Image panelImage;
        [SerializeField] private TextMeshProUGUI scoreText;
        
        public event Action OnClose;
        public event Action OnCollect;
        public Image PanelImage => panelImage;

        private void Awake()
        {
            if (closeButton != null)
            {
                closeButton.onClick.AddListener(HandleClose);
            }

            if (collectButton != null)
            {
                collectButton.onClick.AddListener(HandleCollect);
            }
        }

        private void OnDestroy()
        {
            if (closeButton != null)
            {
                closeButton.onClick.RemoveListener(HandleClose);
            }

            if (collectButton != null)
            {
                collectButton.onClick.RemoveListener(HandleCollect);
            }
        }

        private void HandleClose()
        {
            OnClose?.Invoke();
        }

        private void HandleCollect()
        {
            OnCollect?.Invoke();
        }

        public void SetScoreText(string text)
        {
            if (scoreText != null)
            {
                scoreText.text = text;
            }
        }
    }
}