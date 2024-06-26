using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.Enemy
{
    public class MovementDown : IInitializable, IDisposable
    {
        private const float Half = 0.5f;
        
        private readonly Transform _enemies;
        private readonly EnemyConfig _enemyConfig;
        private readonly DetectingWall _detectingWall;
        private readonly CompositeDisposable _compositeDisposableDetect = new();
        private readonly CompositeDisposable _compositeDisposableTime = new();
        
        public MovementDown(EnemyConfig enemyConfig,
                            EnemyView enemyView,
                            DetectingWall detectingWall)
        {
            _enemyConfig = enemyConfig;
            _enemies = enemyView.EnemyParent;
            _detectingWall = detectingWall;
        }

        public void Initialize()
            => _detectingWall.Detected.Subscribe(_ => WaitToMove()).AddTo(_compositeDisposableDetect);

        public void Dispose()
        {
            _compositeDisposableDetect.Clear();
            _compositeDisposableTime.Clear();
        }

        private void WaitToMove()
            => Observable.Timer(TimeSpan.FromSeconds(_enemyConfig.TimeStayInSec * Half)).Subscribe(_ => Move())
                .AddTo(_compositeDisposableTime);

        private void Move()
        {
            _enemies.position += Vector3.down * _enemyConfig.OffsetMoveDown;
            _compositeDisposableTime.Clear();
        }
    }
}