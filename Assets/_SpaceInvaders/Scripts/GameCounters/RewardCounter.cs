using System;
using _SpaceInvaders.Scripts.Bullet;
using _SpaceInvaders.Scripts.StringValues;
using UniRx;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.GameCounters
{
    public class RewardCounter : IInitializable, IDisposable
    {
        private readonly DetectingEnemy _detectingEnemy;
        private readonly CompositeDisposable _compositeDisposable = new();
        private readonly RewardConfig _rewardConfig;

        private int _counter;

        public RewardCounter(DetectingEnemy detectingEnemy,
                             RewardConfig rewardConfig)
        {
            _detectingEnemy = detectingEnemy;
            _rewardConfig = rewardConfig;
        }
        
        public ReactiveCommand<int> Counted { get; } = new();

        public void Initialize()
            => _detectingEnemy.Detected.Subscribe(AccrueReward).AddTo(_compositeDisposable);

        public void Dispose()
            => _compositeDisposable.Clear();

        private void AccrueReward(GameObject enemy)
        {
            switch (enemy.tag)
            {
                case Tags.Enemy0:
                    _counter += _rewardConfig.RewardEnemy0;
                    break;
                case Tags.Enemy1:
                    _counter += _rewardConfig.RewardEnemy1;
                    break;
                case Tags.Enemy2:
                    _counter += _rewardConfig.RewardEnemy2;
                    break;
            }

            Counted.Execute(_counter);
        }
    }
}