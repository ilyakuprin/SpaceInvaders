using UnityEngine;

namespace _SpaceInvaders.Scripts.MainHero
{
    public class MainHeroView : MonoBehaviour
    {
        [field: SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        [field: SerializeField] public Transform FirePoint { get; private set; }
        [field: SerializeField] public Collider2D Collider { get; private set; }
    }
}