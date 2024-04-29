using System.Linq;
using _SpaceInvaders.Scripts.Inputing;
using Zenject;

namespace _SpaceInvaders.Scripts.Installers
{
    public class InputtingInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(new[] { typeof(PlayerInput) }.Concat(typeof(KeyboardInput).GetInterfaces()))
                .To<KeyboardInput>().AsSingle();
        }
    }
}