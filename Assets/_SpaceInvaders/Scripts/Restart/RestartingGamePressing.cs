using System;
using _SpaceInvaders.Scripts.UI;
using UniRx;
using Zenject;

namespace _SpaceInvaders.Scripts.Restart
{
    public class RestartingGamePressing : IInitializable, IDisposable
    {
        private readonly PressingRestarting _pressingRestarting;
        private readonly CompositeDisposable _compositeDisposable = new();

        public RestartingGamePressing(PressingRestarting pressingRestarting)
        {
            _pressingRestarting = pressingRestarting;
        }

        public void Initialize()
            => _pressingRestarting.Pressed.Subscribe(_ => RestartingGame.Restart()).AddTo(_compositeDisposable);

        public void Dispose()
            => _compositeDisposable.Clear();
    }
}