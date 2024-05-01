using System.Linq;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.Inputting
{
    public class InputtingInstaller : MonoInstaller
    {
        [SerializeField] private JoystickHandler _joystickHandler;
        [SerializeField] private CanvasInputView _canvasInputView;
        
        public override void InstallBindings()
        {
            if (SystemInfo.deviceType == DeviceType.Handheld)
            {
                Container.Bind<JoystickHandler>().FromInstance(_joystickHandler).AsSingle();
                Container.Bind<CanvasInputView>().FromInstance(_canvasInputView).AsSingle();
                
                Container.Bind(new[] { typeof(PlayerInput) }.Concat(typeof(HandheldInput).GetInterfaces()))
                    .To<HandheldInput>().AsSingle();

                Container.BindInterfacesAndSelfTo<ActivatingCanvasInput>().AsSingle();
                Container.BindInterfacesAndSelfTo<PressingFireButton>().AsSingle();
            }
            else
            {
                Container.Bind(new[] { typeof(PlayerInput) }.Concat(typeof(KeyboardInput).GetInterfaces()))
                    .To<KeyboardInput>().AsSingle();
            }
        }
    }
}