using UnityEngine;

namespace _SpaceInvaders.Scripts.GameCounters
{
    [CreateAssetMenu(fileName = "RewardConfig", menuName = "Configs/RewardConfig")]
    public class RewardConfig : ScriptableObject
    {
        [field: SerializeField, Range(1, 1000)] public int RewardEnemy0 { get; private set; }
        [field: SerializeField, Range(1, 1000)] public int RewardEnemy1 { get; private set; }
        [field: SerializeField, Range(1, 1000)] public int RewardEnemy2 { get; private set; }
    }
}