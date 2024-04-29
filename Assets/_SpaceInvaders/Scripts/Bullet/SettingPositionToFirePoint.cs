using System;
using _SpaceInvaders.Scripts.Inputing;
using _SpaceInvaders.Scripts.MainHero;
using UniRx;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.Bullet
{
    public class SettingPositionToFirePoint : IInitializable, IDisposable, IExecutive
    {
        private readonly Transform _bullet;
        private readonly Transform _firePoint;
        private readonly PlayerInput _input;
        private readonly CompositeDisposable _compositeDisposable = new();

        public SettingPositionToFirePoint(BulletView bulletView,
            MainHeroView mainHeroView,
            PlayerInput input)
        {
            _bullet = bulletView.Rigidbody.transform;
            _firePoint = mainHeroView.FirePoint;
            _input = input;
        }

        public void Initialize()
            => _input.ReactiveInput.Subscribe(Execute).AddTo(_compositeDisposable);

        public void Dispose()
            => _compositeDisposable.Clear();

        public void Execute(InputData inputData)
        {
            if (!_bullet.gameObject.activeInHierarchy && inputData.Fire)
                _bullet.position = _firePoint.position;
        }
    }
}