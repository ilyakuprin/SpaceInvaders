using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.MainHero
{
    public class DetectingBullet : IInitializable, IDisposable
    {
        private readonly Collider2D _collider;
        private readonly CompositeDisposable _compositeDisposable = new();

        public DetectingBullet(MainHeroView mainHeroView)
        {
            _collider = mainHeroView.Collider;
        }
        
        public ReactiveCommand Detected { get; } = new();

        public void Initialize()
            => _collider.OnTriggerEnter2DAsObservable().Subscribe(_ => Detected.Execute())
                .AddTo(_compositeDisposable);

        public void Dispose()
            => _compositeDisposable.Clear();
    }
}