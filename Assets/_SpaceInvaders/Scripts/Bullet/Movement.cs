using System;
using _SpaceInvaders.Scripts.Inputing;
using _SpaceInvaders.Scripts.ScriptableObj;
using UniRx;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.Bullet
{
    public class Movement : IInitializable, IFixedTickable, IExecutive, IDisposable
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _speed;
        private readonly PlayerInput _input;
        private readonly CompositeDisposable _compositeDisposable = new();

        public Movement(BulletView bulletView,
                        BulletConfig bulletConfig,
                        PlayerInput input)
        {
            _rigidbody = bulletView.Rigidbody;
            _speed = bulletConfig.Speed;
            _input = input;
        }

        public void Initialize()
            => _input.ReactiveInput.Subscribe(Execute).AddTo(_compositeDisposable);

        public void Dispose()
            => _compositeDisposable.Clear();

        public void Execute(InputData inputData)
        {
            if (!IsActive() && inputData.Fire)
                _rigidbody.gameObject.SetActive(true);
        }

        public void FixedTick()
        {
            if (!IsActive()) return;

            var position = _rigidbody.position;
            var targetPosition = new Vector2(position.x, position.y + _speed * Time.fixedDeltaTime);

            _rigidbody.MovePosition(targetPosition);
        }

        private bool IsActive()
            => _rigidbody.gameObject.activeInHierarchy;
    }
}