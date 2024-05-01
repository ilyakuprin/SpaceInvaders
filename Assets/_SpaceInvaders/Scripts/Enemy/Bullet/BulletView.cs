using System.Linq;
using UnityEngine;

namespace _SpaceInvaders.Scripts.Enemy.Bullet
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D[] _bulletsEnemy1;
        [SerializeField] private Rigidbody2D[] _bulletsEnemy2;
        private Rigidbody2D[] _allBullets;

        public int CountBulletsEnemy1 => _bulletsEnemy1.Length;
        public int CountBulletsEnemy2 => _bulletsEnemy2.Length;
        public int CountAllBullets => _allBullets.Length;

        public Rigidbody2D GetBulletsEnemy1(int index)
            => _bulletsEnemy1[index];

        public Rigidbody2D GetBulletsEnemy2(int index)
            => _bulletsEnemy2[index];
        
        public Rigidbody2D GetBullet(int index)
            => _allBullets[index];

        private void Awake()
            => _allBullets = _bulletsEnemy1.Concat(_bulletsEnemy2).ToArray();
    }
}