using _SpaceInvaders.Scripts.Pause;
using UniRx;

namespace _SpaceInvaders.Scripts.Inputting
{
    public abstract class PlayerInput : IPausable
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