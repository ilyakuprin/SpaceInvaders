using System;
using UniRx;
using Zenject;

namespace _SpaceInvaders.Scripts.Inputting
{
    public abstract class PlayerInput : IInitializable, IDisposable
    {
        private readonly CompositeDisposable _compositeDisposable = new();
        
        public ReactiveCommand<InputData> ReactiveInput { get; } = new ();

        public void Initialize()
            => Observable.EveryUpdate().Subscribe(_ => Execute()).AddTo(_compositeDisposable);

        public void Dispose()
            => _compositeDisposable.Clear();

        protected abstract InputData GetInputData();

        private void Execute()
            => ReactiveInput.Execute(GetInputData());
    }
}