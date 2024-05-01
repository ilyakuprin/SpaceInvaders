using System;
using _SpaceInvaders.Scripts.Pause;
using UniRx;
using UnityEngine;

namespace _SpaceInvaders.Scripts.Enemy
{
    public class HorizontalMovement : IPausable
    {
        private readonly CompositeDisposable _compositeDisposable = new();
        private readonly Transform _enemies;
        private readonly EnemyConfig _enemyConfig;
        
        private Vector3 _direction = Vector3.right;
 
        public HorizontalMovement(EnemyConfig enemyConfig,
                                  EnemyView enemyView)
        {
            _enemyConfig = enemyConfig;
            _enemies = enemyView.EnemyParent;
        }
        
        public void ChangeDirection()
            => _direction = -_direction; 
        
        public void Initialize()
            => StartTimer();

        private void StartTimer()
            => Observable.Timer(TimeSpan.FromSeconds(_enemyConfig.TimeStayInSec)).Subscribe(_ => Move())
                .AddTo(_compositeDisposable);

        private void Move()
        {
            _enemies.position += _direction * _enemyConfig.OffsetHorizontalMove;
            StartTimer();
        }

        public void Dispose()
            => _compositeDisposable.Clear();
    }
}