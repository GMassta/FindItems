using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Content.Scripts
{
    public class GameController: IInitializable, ITickable
    {
        [Inject] 
        private LevelSettings _settings;
        
        private ICameraService _cameraService;
        private IGameOverPopup _gameOverPopup;
        private ILevelService _levelService;
        private IInputService _input;
        private IGameUi _gameUi;

        private List<IItem> availableItems;
        private List<IItem> nextItems;

        private float timer = 0;
        private bool withTimer;
        
        private int _maxNextItemsCount;
        private bool _deactivateGame;

        public GameController(IInputService input, ICameraService cameraService, ILevelService levelService, 
            IGameUi gameUi, IGameOverPopup gameOverPopup)
        {
            _cameraService = cameraService;
            _gameOverPopup = gameOverPopup;
            _levelService = levelService;
            _gameUi = gameUi;
            _input = input;
        }

        public void Initialize()
        {
            _deactivateGame = true;
            StartGame().Forget();
            
            _input.ClickAction += SelectObject;
            _maxNextItemsCount = _settings.MaxItemsCount;
            
            availableItems = _levelService.Items;
            nextItems = new List<IItem>();

            withTimer = _settings.EnableTimer;
            timer = _settings.TimerTime;
            
            _gameUi.CreateElements(_settings.UiItemPrefab, _maxNextItemsCount);

            if (withTimer)
            {
                _gameUi.ShowTimer();
                _gameUi.UpdateTimer(GetTime());
            }
        }

        private async UniTask StartGame()
        {
            await UniTask.Delay(500);
            _deactivateGame = false;
        }

        private void SelectObject(Vector2 position)
        {
            if(_deactivateGame) return;
            
            var pos = _cameraService.Camera.ScreenToWorldPoint(position);
            var rayHit = Physics2D.Raycast(pos, Vector2.zero);

            if (rayHit && rayHit.collider != null)
            {
                var item = rayHit.transform.GetComponent<IItem>();
                if(!nextItems.Contains(item)) return;
                
                nextItems.Remove(item);
                _gameUi.RemoveItem(item);
                item.HideItem();
            }
        }

        public void Tick()
        {
            if(_deactivateGame) return;
            
            if (withTimer)
            {
                _gameUi.UpdateTimer(GetTime());
                
                if (timer <= 0)
                {
                    _deactivateGame = true;
                    _gameOverPopup.Show("Проиграл");
                    return;
                }

                timer -= Time.deltaTime;
                timer = Mathf.Clamp(timer, 0, float.MaxValue);
            }

            if(nextItems.Count >= _maxNextItemsCount) return;

            if (availableItems.Count > 0)
            {
                var nextItem = availableItems[0];
                availableItems.RemoveAt(0);
                _gameUi.AddNewItem(nextItem);
                nextItems.Add(nextItem);
            }
            else if(nextItems.Count <= 0)
            {
                _deactivateGame = true;
                _gameOverPopup.Show("Победа");
            }
        }

        private string GetTime()
        {
            var span = TimeSpan.FromSeconds(Mathf.CeilToInt(timer));
            var result = @"ss";
            if (span.Hours > 0) result = @"hh\:mm\:ss";
            else if (span.Minutes > 0) result = @"mm\:ss";
            return span.ToString(result);
        }
    }
}