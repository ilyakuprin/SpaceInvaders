using UnityEngine;

namespace _SpaceInvaders.Scripts.Enemy.Bullet
{
    [CreateAssetMenu(fileName = "EnemyBulletConfig", menuName = "Configs/EnemyBulletConfig")]
    public class BulletConfig : ScriptableObject
    {
        [field: SerializeField, Range(0.1f, 10f)] public float Speed { get; private set; }
    }
}