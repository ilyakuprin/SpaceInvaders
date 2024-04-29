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
        
        private float _upBorder;

        public HidingBullet(Camera camera,
                            BulletView bulletView)
        {
            _camera = camera;
            _bullet = bulletView.Rigidbody.transform;
        }
        
        public void Initialize()
        {
            _upBorder = _camera.ViewportToWorldPoint(UpperRightCorner).y;

            Observable.EveryUpdate().Subscribe(_ =>
            {
                if (_bullet.position.y > _upBorder)
                {
                    _bullet.gameObject.SetActive(false);
                }
            }).AddTo(_compositeDisposable);
        }

        public void Dispose()
            => _compositeDisposable.Clear();
    }
}