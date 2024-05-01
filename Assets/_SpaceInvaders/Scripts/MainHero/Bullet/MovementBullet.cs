using _SpaceInvaders.Scripts.Pause;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.MainHero.Bullet
{
    public class MovementBullet : IFixedTickable, IPausable
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _speed;

        private bool _isPause;

        public MovementBullet(BulletView bulletView,
                              BulletConfig bulletConfig)
        {
            _rigidbody = bulletView.Rigidbody;
            _speed = bulletConfig.Speed;
        }

        public void Initialize()
            => _isPause = false;

        public void Dispose()
            => _isPause = true;

        public void FixedTick()
        {
            if (!IsActive() || _isPause) return;

            var position = _rigidbody.position;
            var targetPosition = new Vector2(position.x, position.y + _speed * Time.fixedDeltaTime);
            
            _rigidbody.MovePosition(targetPosition);
        }

        private bool IsActive()
            => _rigidbody.gameObject.activeInHierarchy;
    }
}