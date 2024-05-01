using System.Collections.Generic;
using _SpaceInvaders.Scripts.StringValues;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.Enemy
{
    public class SearchingShootingEnemies : IInitializable
    {
        private const int CountShootingEnemy = 2;
        
        private readonly EnemyView _enemyView;
        private readonly int _startCapacity;
        private readonly List<List<Transform>> _shootingEnemies = new (CountShootingEnemy);

        public SearchingShootingEnemies(EnemyView enemyView,
                                        EnemyConfig enemyConfig)
        {
            _enemyView = enemyView;
            _startCapacity = enemyConfig.NumberColumns;
        }

        public List<List<Transform>> GetShootingEnemies()
            => new(_shootingEnemies);

        public void Initialize()
        {
            _shootingEnemies.Add(new List<Transform>(_startCapacity));
            _shootingEnemies.Add(new List<Transform>(_startCapacity));
            
            foreach (var enemy in _enemyView.EnemyParent.GetComponentsInChildren<Transform>())
            {
                if (enemy.CompareTag(Tags.Enemy1))
                    _shootingEnemies[0].Add(enemy.transform);
                else if (enemy.CompareTag(Tags.Enemy2))
                    _shootingEnemies[1].Add(enemy.transform);
            }
        }
    }
}