using UnityEngine;

namespace _SpaceInvaders.Scripts.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        [field: SerializeField] public Transform EnemyParent { get; private set; }
        [field: SerializeField, Range(1f, 3f)] public float HorizontalDistance { get; private set; }
        [field: SerializeField] public Collider2D RightWall { get; private set; }
        [field: SerializeField] public Collider2D LeftWall { get; private set; }
        [field: SerializeField] public Collider2D Bottom { get; private set; }
    }
}