using System;
using UniRx;
using UnityEngine.UI;
using Zenject;

namespace _SpaceInvaders.Scripts.UI
{
    public class PressingPause : IInitializable, IDisposable
    {
        private readonly Button _pause;
        private readonly CompositeDisposable _compositeDisposable = new();

        public PressingPause(UiView uiView)
        {
            _pause = uiView.Pause;
        }

        public ReactiveCommand Pressed { get; } = new();

        public void Initialize()
            => _pause.OnClickAsObservable().Subscribe(_ => Pressed.Execute()).AddTo(_compositeDisposable);

        public void Dispose()
            => _compositeDisposable.Clear();
    }
}