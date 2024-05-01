using Zenject;

namespace _SpaceInvaders.Scripts.Restart
{
    public class RestartingInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RestartingGamePressing>().AsSingle();
            Container.BindInterfacesAndSelfTo<RestartingGameVictory>().AsSingle();
            Container.BindInterfacesAndSelfTo<RestartingGameDefeat>().AsSingle();
        }
    }
}