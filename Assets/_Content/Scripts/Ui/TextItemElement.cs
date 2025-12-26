using TMPro;
using UnityEngine;
using DG.Tweening;

namespace _Content.Scripts
{
    public class TextItemElement : MonoBehaviour, IItemElement
    { 
        private TMP_Text label;

        private void Awake()
        {
            label = GetComponent<TMP_Text>();
        }

        public void SetValue(IItem item)
        {
            label.text = item.GetName;
        }

        public bool CheckItem(IItem item) => label.text.Equals(item.GetName);
        public void Hide(float duration)
        {
            label.DOKill();
            label.DOFade(0, duration).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }

        public void Show(float duration)
        {
            label.DOKill();
            
            gameObject.SetActive(true);
            label.DOFade(1, duration);
        }
    }
}