using System;
using UniRx;
using UnityEngine.UI;
using Zenject;

namespace _SpaceInvaders.Scripts.Inputting
{
    public class PressingFireButton : IInitializable, IDisposable
    {
        private readonly Button _button;
        private readonly CompositeDisposable _compositeDisposable = new();

        public PressingFireButton(CanvasInputView canvasInputView)
        {
            _button = canvasInputView.Fire;
        }
        
        public bool IsFire { get; private set; }

        public void Initialize()
        {
            Observable.EveryUpdate().Subscribe(_ =>
            {
                if (IsFire)
                    IsFire = false;
            }).AddTo(_compositeDisposable);
            
            _button.OnClickAsObservable().Subscribe(_ => IsFire = true).AddTo(_compositeDisposable);
        }

        public void Dispose()
            => _compositeDisposable.Clear();
    }
}