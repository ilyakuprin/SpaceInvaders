using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.UI
{
    public class UnshowingPauseCanvas : IInitializable, IDisposable
    {
        private readonly GameObject _pauseCanvas;
        private readonly PressingUnpause _pressingUnpause;
        private readonly CompositeDisposable _compositeDisposable = new();

        public UnshowingPauseCanvas(UiView uiView,
                                    PressingUnpause pressingUnpause)
        {
            _pauseCanvas = uiView.PauseCanvas.gameObject;
            _pressingUnpause = pressingUnpause;
        }

        public void Initialize()
            => _pressingUnpause.Pressed.Subscribe(_ => _pauseCanvas.SetActive(false)).AddTo(_compositeDisposable);

        public void Dispose()
            => _compositeDisposable.Clear();
    }
}