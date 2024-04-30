using System;
using _SpaceInvaders.Scripts.GameCounters;
using TMPro;
using UniRx;
using Zenject;

namespace _SpaceInvaders.Scripts.UI
{
    public class ShowingScore : IInitializable, IDisposable
    {
        private const string Format = "Scoring: {0}";

        private readonly TextMeshProUGUI _text;
        private readonly RewardCounter _rewardCounter;
        private readonly CompositeDisposable _compositeDisposable = new();

        public ShowingScore(RewardCounter rewardCounter,
                            UiView uiView)
        {
            _rewardCounter = rewardCounter;
            _text = uiView.Score;
        }

        public void Initialize()
            => _rewardCounter.Counted.Subscribe(Show).AddTo(_compositeDisposable);

        public void Dispose()
            => _compositeDisposable.Clear();

        private void Show(int value)
            => _text.text = string.Format(Format, value);
    }
}