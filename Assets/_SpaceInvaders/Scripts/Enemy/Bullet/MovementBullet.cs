using _SpaceInvaders.Scripts.Pause;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.Enemy.Bullet
{
    public class MovementBullet : IFixedTickable, IPausable
    {
        private readonly BulletView _bulletView;
        private readonly float _speed;

        private Transform[] _bullets;
        private bool _isPause;

        public MovementBullet(BulletView bulletView,
                              BulletConfig bulletConfig)
        {
            _bulletView = bulletView;
            _speed = bulletConfig.Speed;
        }

        public void Initialize()
            => _isPause = false;

        public void Dispose()
            => _isPause = true;

        public void FixedTick()
        {
            if (_isPause) return;

            for (var i = 0; i < _bulletView.CountAllBullets; i++)
            {
                var bullet = _bulletView.GetBullet(i);
                
                if (!bullet.gameObject.activeInHierarchy) continue;
                
                var position = bullet.position;
                var targetPosition = new Vector2(position.x, position.y - _speed * Time.fixedDeltaTime);
            
                bullet.MovePosition(targetPosition);
            }
        }
    }
}