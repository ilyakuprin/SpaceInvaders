using System;
using _SpaceInvaders.Scripts.UI;
using UniRx;
using Zenject;

namespace _SpaceInvaders.Scripts.Pause
{
    public class SettingUnpause : IInitializable, IDisposable
    {
        private readonly IPausable[] _pausables;
        private readonly PressingUnpause _pressingUnpause;
        private readonly CompositeDisposable _compositeDisposable = new();
        
        public SettingUnpause(IPausable[] pausables,
                              PressingUnpause pressingUnpause)
        {
            _pausables = pausables;
            _pressingUnpause = pressingUnpause;
        }

        public void Initialize()
            => _pressingUnpause.Pressed.Subscribe(_ => Unpause()).AddTo(_compositeDisposable);

        public void Dispose()
            => _compositeDisposable.Clear();

        private void Unpause()
        {
            foreach (var pausable in _pausables)
            {
                pausable.Initialize();
            }
        }
    }
}