using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.Enemy
{
    public class Movement : IInitializable, IDisposable
    {
        private readonly CompositeDisposable _compositeDisposable = new();
        private readonly Transform _enemies;
        private readonly EnemyConfig _enemyConfig;

        private float _direction = 1f;
 
        public Movement(EnemyConfig enemyConfig,
                        EnemyView enemyView)
        {
            _enemyConfig = enemyConfig;
            _enemies = enemyView.EnemyParent;
        }
        
        public void ChangeDirection() => _direction *= -1f; 
        
        public void Initialize()
            => StartTimer();

        private void StartTimer()
        {
            Observable.Timer(TimeSpan.FromSeconds(_enemyConfig.TimeStayInSec)).Subscribe(_ =>
            {
                Move();
            }).AddTo(_compositeDisposable);
        }

        private void Move()
        {
            _enemies.position += Vector3.right * _direction * _enemyConfig.OffsetMove;
            StartTimer();
        }

        public void Dispose()
            => _compositeDisposable.Clear();
    }
}