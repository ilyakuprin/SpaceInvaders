using System;
using UniRx;
using UnityEngine.UI;
using Zenject;

namespace _SpaceInvaders.Scripts.UI
{
    public class PressingUnpause : IInitializable, IDisposable
    {
        private readonly Button _unpause;
        private readonly CompositeDisposable _compositeDisposable = new();

        public PressingUnpause(UiView uiView)
        {
            _unpause = uiView.Unpause;
        }

        public ReactiveCommand Pressed { get; } = new();

        public void Initialize()
            => _unpause.OnClickAsObservable().Subscribe(_ => Pressed.Execute()).AddTo(_compositeDisposable);

        public void Dispose()
            => _compositeDisposable.Clear();
    }
}