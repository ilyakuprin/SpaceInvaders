using System;
using UniRx;
using UnityEngine.UI;
using Zenject;

namespace _SpaceInvaders.Scripts.UI
{
    public class PressingRestarting : IInitializable, IDisposable
    {
        private readonly Button _restart;
        private readonly CompositeDisposable _compositeDisposable = new();

        public PressingRestarting(UiView uiView)
        {
            _restart = uiView.Restart;
        }

        public ReactiveCommand Pressed { get; } = new();

        public void Initialize()
            => _restart.OnClickAsObservable().Subscribe(_ => Pressed.Execute()).AddTo(_compositeDisposable);

        public void Dispose()
            => _compositeDisposable.Clear();
    }
}