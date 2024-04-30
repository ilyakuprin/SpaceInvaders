using System.Linq;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.Enemy
{
    public class EnemyStorage : IInitializable
    {
        private readonly EnemyConfig _enemyConfig;
        private readonly EnemyView _enemyView;
        private readonly DiContainer _diContainer;
        
        private Transform[,] _enemies;

        public EnemyStorage(EnemyConfig enemyConfig,
                            EnemyView enemyView,
                            DiContainer diContainerContainer)
        {
            _enemyConfig = enemyConfig;
            _enemyView = enemyView;
            _diContainer = diContainerContainer;
        }
        
        /*public int CountRow => _enemies.GetLength(0);
        public int CountColumn => _enemies.GetLength(1);

        public bool TryGetLeftmostEnemy(out Transform enemy)
        {
            for (var i = 0; i < CountColumn; i++)
            {
                for (var j = 0; j < CountRow; j++)
                {
                    if (_enemies[j, i] == null) continue;
                    
                    enemy = _enemies[j, i];
                    return true;
                }
            }

            enemy = null;
            return false;
        }
        
        public bool TryGetRightmostEnemy(out Transform enemy)
        {
            for (var i = CountColumn - 1; i >= 0; i--)
            {
                for (var j = 0; j < CountRow; j++)
                {
                    if (_enemies[j, i] == null) continue;
                    
                    enemy = _enemies[j, i];
                    return true;
                }
            }

            enemy = null;
            return false;
        }

        public Transform GetEnemy(int indexRow, int indexColumn)
            => _enemies[indexRow, indexColumn];*/

        public void Initialize()
            => CreateEnemies();

        private void CreateEnemies()
        {
            _enemies = new Transform[_enemyConfig.EnemiesInColumn.childCount, _enemyConfig.NumberColumns];

            var startPositionX = -(_enemyConfig.NumberColumns - 1);
            
            for (var i = 0; i < _enemyConfig.NumberColumns; i++)
            {
                var lineEnemy = _diContainer.InstantiatePrefab(_enemyConfig.EnemiesInColumn, _enemyView.EnemyParent);

                var position = lineEnemy.transform.position;
                position = new Vector3(startPositionX + _enemyView.HorizontalDistance * i, position.y, position.z);
                lineEnemy.transform.position = position;

                var children = lineEnemy.GetComponentsInChildren<Transform>().Skip(1).ToArray();

                for (var j = 0; j < children.Count(); j++)
                {
                    _enemies[j, i] = children[j];
                }
            }
        }
    }
}