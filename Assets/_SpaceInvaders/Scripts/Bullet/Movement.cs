using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.Bullet
{
    public class Movement : IFixedTickable
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _speed;

        public Movement(BulletView bulletView,
                        BulletConfig bulletConfig)
        {
            _rigidbody = bulletView.Rigidbody;
            _speed = bulletConfig.Speed;
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