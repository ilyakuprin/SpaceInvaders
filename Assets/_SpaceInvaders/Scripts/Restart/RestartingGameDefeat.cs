using System;
using _SpaceInvaders.Scripts.Enemy;
using UniRx;
using Zenject;

namespace _SpaceInvaders.Scripts.Restart
{
    public class RestartingGameDefeat : IInitializable, IDisposable
    {
        private readonly DetectingBottom _detectingBottom;
        private readonly CompositeDisposable _compositeDisposable = new();

        public RestartingGameDefeat(DetectingBottom detectingBottom)
        {
            _detectingBottom = detectingBottom;
        }

        public void Initialize()
            => _detectingBottom.Lost.Subscribe(_ => RestartingGame.Restart()).AddTo(_compositeDisposable);

        public void Dispose()
            => _compositeDisposable.Clear();
    }
}