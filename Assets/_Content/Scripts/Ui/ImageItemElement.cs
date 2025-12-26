using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Content.Scripts
{
    public class ImageItemElement : MonoBehaviour, IItemElement
    {
        private Image icon;
        private string itemName;

        private void Awake()
        {
            icon = GetComponent<Image>();
        }

        public void SetValue(IItem item)
        {
            icon.sprite = item.GetIcon;
            itemName = item.GetName;
        }

        public bool CheckItem(IItem item) => itemName.Equals(item.GetName);

        public void Hide(float duration)
        {
            icon.DOKill();
            icon.DOFade(0, duration).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }

        public void Show(float duration)
        {
            icon.DOKill();
            
            gameObject.SetActive(true);
            icon.DOFade(1, duration);
        }
    }
}