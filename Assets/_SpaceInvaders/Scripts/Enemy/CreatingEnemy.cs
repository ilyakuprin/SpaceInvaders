using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.Enemy
{
    public class CreatingEnemy : IInitializable
    {
        private readonly EnemyConfig _enemyConfig;
        private readonly EnemyView _enemyView;
        private readonly DiContainer _diContainer;

        public CreatingEnemy(EnemyConfig enemyConfig,
                            EnemyView enemyView,
                            DiContainer diContainerContainer)
        {
            _enemyConfig = enemyConfig;
            _enemyView = enemyView;
            _diContainer = diContainerContainer;
        }
        
        public void Initialize()
            => Create();

        private void Create()
        {
            var startPositionX = -(_enemyConfig.NumberColumns - 1);

            for (var i = 0; i < _enemyConfig.NumberColumns; i++)
            {
                var lineEnemy = 
                    _diContainer.InstantiatePrefab(_enemyConfig.EnemiesInColumn, _enemyView.EnemyParent).transform;

                var position = lineEnemy.position;
                position = new Vector3(startPositionX + _enemyView.HorizontalDistance * i, position.y, position.z);
                lineEnemy.position = position;
            }
        }
    }
}