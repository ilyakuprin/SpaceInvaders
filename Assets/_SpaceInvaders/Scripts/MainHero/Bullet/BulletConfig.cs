using UnityEngine;

namespace _SpaceInvaders.Scripts.MainHero.Bullet
{
    [CreateAssetMenu(fileName = "MainHeroBulletConfig", menuName = "Configs/MainHeroBulletConfig")]
    public class BulletConfig : ScriptableObject
    {
        [field: SerializeField, Range(0.1f, 10f)] public float Speed { get; private set; }
    }
}