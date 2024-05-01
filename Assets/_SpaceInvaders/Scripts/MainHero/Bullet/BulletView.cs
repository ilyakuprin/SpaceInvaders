using UnityEngine;

namespace _SpaceInvaders.Scripts.MainHero.Bullet
{
    public class BulletView : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        [field: SerializeField] public Collider2D Collider { get; private set; }
    }
}