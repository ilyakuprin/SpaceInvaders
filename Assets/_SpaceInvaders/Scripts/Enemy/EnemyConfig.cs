using UnityEngine;

namespace _SpaceInvaders.Scripts.Enemy
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField] public Transform EnemiesInColumn { get; private set; }
        [field: SerializeField, Range(1, 15)] public int NumberColumns { get; private set; }
        [field: SerializeField, Range(0.5f, 2f)] public float OffsetMove { get; private set; }
        [field: SerializeField, Range(0.1f, 5f)] public float TimeStayInSec { get; private set; }
    }
}