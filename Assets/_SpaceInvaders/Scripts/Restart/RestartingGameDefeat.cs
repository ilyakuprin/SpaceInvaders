using System;
using _SpaceInvaders.Scripts.Enemy;
using _SpaceInvaders.Scripts.MainHero;
using UniRx;
using Zenject;

namespace _SpaceInvaders.Scripts.Restart
{
    public class RestartingGameDefeat : IInitializable, IDisposable
    {
        private readonly DetectingBottom _detectingBottom;
        private readonly DetectingBullet _detectingBullet;
        private readonly CompositeDisposable _compositeDisposable = new();

        public RestartingGameDefeat(DetectingBottom detectingBottom,
                                    DetectingBullet detectingBullet)
        {
            _detectingBottom = detectingBottom;
            _detectingBullet = detectingBullet;
        }

        public void Initialize()
        {
            _detectingBullet.Detected.Subscribe(_ => RestartingGame.Restart()).AddTo(_compositeDisposable);
            _detectingBottom.Lost.Subscribe(_ => RestartingGame.Restart()).AddTo(_compositeDisposable);
        }

        public void Dispose()
            => _compositeDisposable.Clear();
    }
}