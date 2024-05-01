using System;
using _SpaceInvaders.Scripts.Bullet;
using UniRx;
using Zenject;

namespace _SpaceInvaders.Scripts.Enemy
{
    public class EnemyCounter : IInitializable, IDisposable
    {
        private readonly EnemyConfig _enemyConfig;
        private readonly DetectingEnemy _detectingEnemy;
        private readonly CompositeDisposable _compositeDisposable = new();

        private int _totalCount;

        public EnemyCounter(EnemyConfig enemyConfig,
                            DetectingEnemy detectingEnemy)
        {
            _enemyConfig = enemyConfig;
            _detectingEnemy = detectingEnemy;
        }

        public ReactiveCommand Won { get; } = new();

        public void Initialize()
        {
            _totalCount = _enemyConfig.NumberColumns * _enemyConfig.EnemiesInColumn.childCount;

            _detectingEnemy.Detected.Subscribe(_ => Subtract()).AddTo(_compositeDisposable);
        }

        public void Dispose()
            => _compositeDisposable.Clear();

        private void Subtract()
        {
            _totalCount--;

            if (_totalCount <= 0)
            {
                Won.Execute();
            }
        }
    }
}