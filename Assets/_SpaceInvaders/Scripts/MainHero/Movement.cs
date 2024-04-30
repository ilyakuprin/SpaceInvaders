using System;
using _SpaceInvaders.Scripts.Inputing;
using UniRx;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.MainHero
{
    public class Movement : IInitializable, IDisposable, IExecutive, IFixedTickable
    {
        private readonly CompositeDisposable _compositeDisposable = new();
        private readonly Rigidbody2D _rigidbody;
        private readonly float _speed;
        private readonly PlayerInput _input;

        private float _horizontalForce;
        private Vector2 _moveVelocity;

        public Movement(MainHeroView mainHeroView,
                        MainHeroConfig mainHeroConfig,
                        PlayerInput input)
        {
            _rigidbody = mainHeroView.Rigidbody;
            _speed = mainHeroConfig.Speed;
            _input = input;
        }

        public void Initialize()
            => _input.ReactiveInput.Subscribe(Execute).AddTo(_compositeDisposable);

        public void Dispose()
            => _compositeDisposable.Clear();

        public void Execute(InputData inputData)
            => _moveVelocity = inputData.Direction.normalized * _speed;

        public void FixedTick()
        {
            if (_moveVelocity is { x: 0, y: 0 }) return;
            
            var targetPosition = _rigidbody.position + _moveVelocity * Time.fixedDeltaTime;
            _rigidbody.MovePosition(targetPosition);
        }
    }
}