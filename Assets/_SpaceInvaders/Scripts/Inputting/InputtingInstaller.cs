using System.Linq;
using Zenject;

namespace _SpaceInvaders.Scripts.Inputting
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