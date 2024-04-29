using System;
using UniRx;
using Zenject;

namespace _SpaceInvaders.Scripts.Inputing
{
    public abstract class PlayerInput : IInitializable, IDisposable
    {
        private readonly CompositeDisposable _compositeDisposable = new();
        
        public ReactiveCommand<InputData> ReactiveInput { get; } = new ();

        public void Initialize()
        {
            Observable.EveryUpdate().Subscribe(_ =>
            {
                ReactiveInput.Execute(GetInputData());
            }).AddTo(_compositeDisposable);
        }

        public void Dispose()
            => _compositeDisposable.Clear();

        protected abstract InputData GetInputData();
    }
}