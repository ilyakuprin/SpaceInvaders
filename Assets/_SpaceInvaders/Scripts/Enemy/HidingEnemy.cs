using System;
using _SpaceInvaders.Scripts.MainHero.Bullet;
using UniRx;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.Enemy
{
    public class HidingEnemy : IInitializable, IDisposable
    {
        private readonly DetectingEnemy _detectingEnemy;
        private readonly CompositeDisposable _compositeDisposable = new();

        public HidingEnemy(DetectingEnemy detectingEnemy)
        {
            _detectingEnemy = detectingEnemy;
        }

        public void Initialize()
            => _detectingEnemy.Detected.Subscribe(Hide).AddTo(_compositeDisposable);

        public void Dispose()
            => _compositeDisposable.Clear();
        
        private static void Hide(GameObject enemy)
            => enemy.SetActive(false);
    }
}