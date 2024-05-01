using System;
using _SpaceInvaders.Scripts.Inputting;
using _SpaceInvaders.Scripts.MainHero.Bullet;
using UniRx;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.MainHero
{
    public class Shooting : IInitializable, IDisposable, IExecutive
    {
        private readonly PlayerInput _input;
        private readonly CompositeDisposable _compositeDisposable = new();
        private readonly GameObject _bullet;

        public Shooting(PlayerInput input,
                        BulletView bulletView)
        {
            _input = input;
            _bullet = bulletView.Rigidbody.gameObject;
        }
        
        public ReactiveCommand Shot { get; } = new();
        
        public void Initialize()
            => _input.ReactiveInput.Subscribe(Execute).AddTo(_compositeDisposable);
        
        public void Dispose()
            => _compositeDisposable.Clear();
        
        public void Execute(InputData inputData)
        {
            if (!_bullet.activeInHierarchy && inputData.Fire)
                Shot.Execute();
        }
    }
}