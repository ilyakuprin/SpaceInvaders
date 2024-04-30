using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.Enemy
{
    public class ChangingDirection : IInitializable, IDisposable
    {
        private readonly Collider2D _rightWall;
        private readonly Collider2D _leftWall;
        private readonly CompositeDisposable _compositeDisposable = new();
        private readonly Movement _movement;

        public ChangingDirection(EnemyView enemyView,
                                 Movement movement)
        {
            _rightWall = enemyView.RightWall;
            _leftWall = enemyView.LeftWall;
            _movement = movement;
        }
        
        public void Initialize()
            => DetectRightWall();

        private void DetectRightWall()
        {
            _rightWall.OnTriggerEnter2DAsObservable().First().Subscribe(other =>
            {
                _movement.ChangeDirection();
                DetectLeftWall();
            }).AddTo(_compositeDisposable);
        }

        private void DetectLeftWall()
        {
            _leftWall.OnTriggerEnter2DAsObservable().First().Subscribe(other =>
            {
                _movement.ChangeDirection();
                DetectRightWall();
            }).AddTo(_compositeDisposable);
        }

        public void Dispose()
            => _compositeDisposable.Clear();
    }
}