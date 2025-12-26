using UnityEngine.AddressableAssets;
using System.Collections.Generic;
using _Content.Scripts.Utils;
using VContainer.Unity;
using UnityEngine;

namespace _Content.Scripts
{
    public class LevelService: IInitializable, ILevelService
    {
        private LevelSettings _settings;
        private SpriteRenderer _levelBackground;
        private List<IItem> _items;

        public SpriteRenderer LevelBackground => _levelBackground;
        public List<IItem> Items => _items;
        
        public LevelService(LevelSettings settings)
        {
            _settings = settings;
        }

        public void Initialize()
        {
            var levelObject = Addressables.InstantiateAsync(_settings.LevelPrefab).WaitForCompletion();
            _levelBackground = levelObject.GetComponentInChildren<SpriteRenderer>();
            
            _items = new List<IItem>();

            foreach (var itemRef in _settings.Items)
            {
                var obj = Addressables.InstantiateAsync(itemRef).WaitForCompletion();
                var item = obj.GetComponent<Item>();
                
                if(!item) continue;
                _items.Add(item);
            }
            
            if(_settings.RandomItems)
                _items.Shuffle();
        }
    }
}