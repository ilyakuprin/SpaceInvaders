using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.UI
{
    public class ShowingPauseCanvas : IInitializable, IDisposable
    {
        private readonly GameObject _pauseCanvas;
        private readonly PressingPause _pressingPause;
        private readonly CompositeDisposable _compositeDisposable = new();

        public ShowingPauseCanvas(UiView uiView,
                                  PressingPause pressingPause)
        {
            _pauseCanvas = uiView.PauseCanvas.gameObject;
            _pressingPause = pressingPause;
        }

        public void Initialize()
            => _pressingPause.Pressed.Subscribe(_ => _pauseCanvas.SetActive(true)).AddTo(_compositeDisposable);

        public void Dispose()
            => _compositeDisposable.Clear();
    }
}