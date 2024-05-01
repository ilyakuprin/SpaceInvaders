using System;
using _SpaceInvaders.Scripts.Enemy;
using UniRx;
using Zenject;

namespace _SpaceInvaders.Scripts.Restart
{
    public class RestartingGameVictory : IInitializable, IDisposable
    {
        private readonly EnemyCounter _enemyCounter;
        private readonly CompositeDisposable _compositeDisposable = new();

        public RestartingGameVictory(EnemyCounter enemyCounter)
        {
            _enemyCounter = enemyCounter;
        }

        public void Initialize()
            => _enemyCounter.Won.Subscribe(_ => RestartingGame.Restart()).AddTo(_compositeDisposable);

        public void Dispose()
            => _compositeDisposable.Clear();
    }
}