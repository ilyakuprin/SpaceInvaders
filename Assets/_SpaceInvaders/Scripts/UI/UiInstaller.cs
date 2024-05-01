using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.UI
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] private UiView _uiView;
        
        public override void InstallBindings()
        {
            Container.Bind<UiView>().FromInstance(_uiView).AsSingle();

            Container.BindInterfacesAndSelfTo<ShowingScore>().AsSingle();
            Container.BindInterfacesAndSelfTo<PressingPause>().AsSingle();
            Container.BindInterfacesAndSelfTo<PressingUnpause>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShowingPauseCanvas>().AsSingle();
            Container.BindInterfacesAndSelfTo<UnshowingPauseCanvas>().AsSingle();
            Container.BindInterfacesAndSelfTo<PressingRestarting>().AsSingle();
        }
    }
}