using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.GameCounters
{
    public class GameCountersInstaller : MonoInstaller
    {
        [SerializeField] private RewardConfig _rewardConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<RewardConfig>().FromInstance(_rewardConfig).AsSingle();
            
            Container.BindInterfacesAndSelfTo<RewardCounter>().AsSingle();
        }
    }
}