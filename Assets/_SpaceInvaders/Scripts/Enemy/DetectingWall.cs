using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.Enemy
{
    public class DetectingWall : IInitializable, IDisposable
    {
        private readonly Collider2D _rightWall;
        private readonly Collider2D _leftWall;
        private readonly CompositeDisposable _compositeDisposable = new();

        public DetectingWall(EnemyView enemyView)
        {
            _rightWall = enemyView.RightWall;
            _leftWall = enemyView.LeftWall;
        }

        public ReactiveCommand DetectedWall { get; } = new();
        
        public void Initialize()
            => DetectRightWall();

        private void DetectRightWall()
        {
            _rightWall.OnTriggerEnter2DAsObservable().Subscribe(other =>
            {
                Dispose();
                DetectedWall.Execute();
                DetectLeftWall();
            }).AddTo(_compositeDisposable);
        }

        private void DetectLeftWall()
        {
            _leftWall.OnTriggerEnter2DAsObservable().Subscribe(other =>
            {
                Dispose();
                DetectedWall.Execute();
                DetectRightWall();
            }).AddTo(_compositeDisposable);
        }

        public void Dispose()
            => _compositeDisposable.Clear();
    }
}