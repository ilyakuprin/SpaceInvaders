using UnityEngine;

namespace _SpaceInvaders.Scripts.ScriptableObj
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "Configs/BulletConfig")]
    public class BulletConfig : ScriptableObject
    {
        [field: SerializeField, Range(0.1f, 10f)] public float Speed { get; private set; }
    }
}