using System;
using _SpaceInvaders.Scripts.UI;
using UniRx;
using Zenject;

namespace _SpaceInvaders.Scripts.Pause
{
    public class SettingPause : IInitializable, IDisposable
    {
        private readonly IPausable[] _pausables;
        private readonly PressingPause _pressingPause;
        private readonly CompositeDisposable _compositeDisposable = new();
        
        public SettingPause(IPausable[] pausables,
                            PressingPause pressingPause)
        {
            _pausables = pausables;
            _pressingPause = pressingPause;
        }

        public void Initialize()
            => _pressingPause.Pressed.Subscribe(_ => Pause()).AddTo(_compositeDisposable);

        public void Dispose()
            => _compositeDisposable.Clear();

        private void Pause()
        {
            foreach (var pausable in _pausables)
            {
                pausable.Dispose();
            }
        }
    }
}