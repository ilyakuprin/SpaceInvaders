using Zenject;

namespace _SpaceInvaders.Scripts.Pause
{
    public class PauseInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SettingPause>().AsSingle();
            Container.BindInterfacesAndSelfTo<SettingUnpause>().AsSingle();
        }
    }
}