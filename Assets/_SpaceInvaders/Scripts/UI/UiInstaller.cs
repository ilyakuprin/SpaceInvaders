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
        }
    }
}