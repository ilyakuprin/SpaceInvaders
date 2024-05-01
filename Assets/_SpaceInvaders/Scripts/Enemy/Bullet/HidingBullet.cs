using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.Enemy.Bullet
{
    public class HidingBullet : IInitializable, IDisposable
    {
        private static readonly Vector3 LowerLeftCorner = new (0, 0, 0);
        
        private readonly Camera _camera;
        private readonly BulletView _bulletView;
        private readonly CompositeDisposable _compositeDisposable = new();
        
        private float _loweBorder;

        public HidingBullet(Camera camera,
                            BulletView bulletView)
        {
            _camera = camera;
            _bulletView = bulletView;
        }
        
        public void Initialize()
            => DetectBulletBehindScreen();

        public void Dispose()
            => _compositeDisposable.Clear();

        private void DetectBulletBehindScreen()
        {
            _loweBorder = _camera.ViewportToWorldPoint(LowerLeftCorner).y;
            
            Observable.EveryUpdate().Subscribe(_ =>
            {
                for (var i = 0; i < _bulletView.CountAllBullets; i++)
                {
                    if (_bulletView.GetBullet(i).position.y < _loweBorder)
                    {
                        _bulletView.GetBullet(i).gameObject.SetActive(false);
                    }
                }
            }).AddTo(_compositeDisposable);
        }
    }
}