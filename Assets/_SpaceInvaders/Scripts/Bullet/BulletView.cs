using UnityEngine;

namespace _SpaceInvaders.Scripts.Bullet
{
    public class BulletView : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
    }
}