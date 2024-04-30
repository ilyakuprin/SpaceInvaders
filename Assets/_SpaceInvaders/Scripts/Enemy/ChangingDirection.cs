using System;
using UniRx;
using Zenject;

namespace _SpaceInvaders.Scripts.Enemy
{
    public class ChangingDirection : IInitializable, IDisposable
    {
        private readonly DetectingWall _detectingWall;
        private readonly HorizontalMovement _horizontalMovement;
        private readonly CompositeDisposable _compositeDisposable = new();

        public ChangingDirection(DetectingWall detectingWall,
                                HorizontalMovement horizontalMovement)
        {
            _detectingWall = detectingWall;
            _horizontalMovement = horizontalMovement;
        }

        public void Initialize()
            => _detectingWall.Detected.Subscribe(_ => _horizontalMovement.ChangeDirection())
                .AddTo(_compositeDisposable);

        public void Dispose()
            => _compositeDisposable.Clear();
    }
}