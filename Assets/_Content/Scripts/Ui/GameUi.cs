using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Content.Scripts
{
    public class GameUi : MonoBehaviour, IGameUi
    {
        [Tooltip("Область, где будут отображаться предметы для поиска")]
        [SerializeField] private Transform itemsArea;
        [Tooltip("Игровой таймер")]
        [SerializeField] private TMP_Text timer;

        private List<IItemElement> _uiItems;
        private List<IItemElement> _usedUiItems;
        
        public void CreateElements(AssetReference prefab, int count)
        {
            _usedUiItems = new List<IItemElement>();
            _uiItems = new List<IItemElement>();
            
            var loadedPrefab = Addressables.LoadAssetAsync<GameObject>(prefab).WaitForCompletion();

            for (int i = 0; i < count; i++)
            {
                var obj = Instantiate(loadedPrefab, itemsArea);
                var uiItems = obj.GetComponent<IItemElement>();
                uiItems.Hide(0);
                _uiItems.Add(uiItems);
            }
        }

        public void AddNewItem(IItem nextItem)
        {
            var element = GetFirstElement();
            element.SetValue(nextItem);
            element.Show(.5f);
        }

        public void RemoveItem(IItem item)
        {
            var removedItem = _usedUiItems.First(x => x.CheckItem(item));
            _usedUiItems.Remove(removedItem);
            _uiItems.Add(removedItem);
            
            removedItem.Hide(.5f);
        }
        
        public void UpdateTimer(string time)
        {
            timer.text = time;
        }

        public void ShowTimer()
        {
            timer.gameObject.SetActive(true);
            timer.DOFade(1, .5f);
        }

        private IItemElement GetFirstElement()
        {
            var element = _uiItems[0];
            _uiItems.RemoveAt(0);
            _usedUiItems.Add(element);

            return element;
        }
    }
}