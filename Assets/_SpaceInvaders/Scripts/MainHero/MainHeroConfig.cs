using UnityEngine;

namespace _SpaceInvaders.Scripts.MainHero
{
    [CreateAssetMenu(fileName = "MainHeroConfig", menuName = "Configs/MainHeroConfig")]
    public class MainHeroConfig : ScriptableObject
    {
        [field: SerializeField, Range(1f, 5f)] public float FinishLineHeightInMainHero { get; private set; }
        [field: SerializeField, Range(0.1f, 10f)] public float Speed { get; private set; }
    }
}