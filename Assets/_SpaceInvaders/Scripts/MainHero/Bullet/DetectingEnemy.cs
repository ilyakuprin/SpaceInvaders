using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.MainHero.Bullet
{
    public class DetectingEnemy : IInitializable, IDisposable
    {
        private readonly Collider2D _collider;
        private readonly CompositeDisposable _compositeDisposableDetecting = new();
        private readonly CompositeDisposable _compositeDisposableShot = new();
        private readonly Shooting _shooting;

        public DetectingEnemy(BulletView bulletView,
                              Shooting shooting)
        {
            _collider = bulletView.Collider;
            _shooting = shooting;
        }
        
        public ReactiveCommand<GameObject> Detected { get; } = new();

        public void Initialize()
            => _shooting.Shot.Subscribe(_ => StartDetect()).AddTo(_compositeDisposableShot);

        public void Dispose()
        {
            ClearDetect();
            _compositeDisposableShot.Clear();
        }
        
        private void ClearDetect()
            => _compositeDisposableDetecting.Clear();

        private void StartDetect()
        {
            if (_compositeDisposableDetecting.Count == 0)
            {
                _collider.OnTriggerEnter2DAsObservable().Subscribe(Detect).AddTo(_compositeDisposableDetecting);
            }
        }

        private void Detect(Collider2D enemy)
        {
            ClearDetect();
            Detected.Execute(enemy.gameObject);
        }
    }
}