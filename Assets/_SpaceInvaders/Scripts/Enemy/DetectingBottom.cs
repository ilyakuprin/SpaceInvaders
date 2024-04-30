using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.Enemy
{
    public class DetectingBottom : IInitializable, IDisposable
    {
        private readonly Collider2D _bottom;
        private readonly CompositeDisposable _compositeDisposable = new();

        public DetectingBottom(EnemyView enemyView)
        {
            _bottom = enemyView.Bottom;
        }
        
        public void Initialize()
        {
            _bottom.OnTriggerEnter2DAsObservable().Subscribe(other =>
            {
                Dispose();
                Debug.Log("Поражение");
            }).AddTo(_compositeDisposable);
        }

        public void Dispose()
            => _compositeDisposable.Clear();
    }
}