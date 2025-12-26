using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Content.Scripts
{
    public class GameOverPopup : MonoBehaviour, IGameOverPopup
    {
        [Tooltip("Кнопка выхода из игры")]
        [SerializeField] private Button exitButton;
        [Tooltip("Текст отображения статуса окончания игры")]
        [SerializeField] private TMP_Text gameOverMessage;
        [Tooltip("Бэкграунд окна окончания игры")]
        [SerializeField] private Image gameOverBackground;
        [Tooltip("Окно окончания игры")]
        [SerializeField] private RectTransform gameOverWindow;

        private void Start()
        {
            exitButton.onClick.AddListener(Exit);
        }

        private void Exit()
        {
            Application.Quit();
        }

        public void Show(string message)
        {
            gameOverBackground.gameObject.SetActive(true);
            gameOverMessage.text = message;
            
            var seq = DOTween.Sequence();
            seq.Append(gameOverBackground.DOFade(0, 0));
            seq.Append(gameOverWindow.DOScale(0, 0));
            seq.Append(gameOverBackground.DOFade(.8f, .5f));
            seq.Append(gameOverWindow.DOScale(1f, .5f));
        }
    }
}