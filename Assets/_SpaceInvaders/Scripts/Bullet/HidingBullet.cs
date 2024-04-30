using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.Bullet
{
    public class HidingBullet : IInitializable, IDisposable
    {
        private static readonly Vector3 UpperRightCorner = new (1, 1, 0);
        
        private readonly Camera _camera;
        private readonly Transform _bullet;
        private readonly CompositeDisposable _compositeDisposable = new();
        private readonly DetectingEnemy _detectingEnemy;
        
        private float _upBorder;

        public HidingBullet(Camera camera,
                            BulletView bulletView,
                            DetectingEnemy detectingEnemy)
        {
            _camera = camera;
            _bullet = bulletView.Rigidbody.transform;
            _detectingEnemy = detectingEnemy;
        }
        
        public void Initialize()
        {
            DetectBulletBehindScreen();
            DetectCollisionWithEnemy();
        }

        public void Dispose()
            => _compositeDisposable.Clear();

        private void DetectBulletBehindScreen()
        {
            _upBorder = _camera.ViewportToWorldPoint(UpperRightCorner).y;
            
            Observable.EveryUpdate().Subscribe(_ =>
            {
                if (_bullet.position.y > _upBorder)
                {
                    Hide();
                }
            }).AddTo(_compositeDisposable);
        }

        private void DetectCollisionWithEnemy()
            => _detectingEnemy.Detected.Subscribe(_ => Hide()).AddTo(_compositeDisposable);

        private void Hide()
            => _bullet.gameObject.SetActive(false);
    }
}