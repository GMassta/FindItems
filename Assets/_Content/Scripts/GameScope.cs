using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Content.Scripts
{
    public class GameScope: LifetimeScope
    {
        [SerializeField] private GameUi _gameUi;
        [SerializeField] private GameOverPopup _gameOver;
        [SerializeField] private LevelSettings _settings;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_settings);
            builder.RegisterComponent(_gameUi).As<IGameUi>().AsSelf();
            builder.RegisterComponent(_gameOver).As<IGameOverPopup>().AsSelf();

            builder.Register<IInputService, InputService>(Lifetime.Singleton).AsSelf();
            builder.RegisterEntryPoint<LevelService>().AsSelf();
            builder.RegisterEntryPoint<CameraService>().AsSelf();

            builder.RegisterEntryPoint<GameController>();
        }
    }
}