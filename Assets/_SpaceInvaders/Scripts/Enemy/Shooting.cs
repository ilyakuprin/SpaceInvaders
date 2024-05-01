using System.Collections.Generic;
using _SpaceInvaders.Scripts.Enemy.Bullet;
using _SpaceInvaders.Scripts.Pause;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _SpaceInvaders.Scripts.Enemy
{
    public class Shooting : IPausable
    {
        private readonly BulletView _bulletView;
        private readonly EnemyConfig _enemyConfig;
        private readonly SearchingShootingEnemies _searchingShootingEnemies;
        private readonly CompositeDisposable _compositeDisposable = new();

        private List<List<Transform>> _shootingEnemies;
        private float _timeInterval;

        public Shooting(SearchingShootingEnemies searchingShootingEnemies,
                        EnemyConfig enemyConfig,
                        BulletView bulletView)
        {
            _searchingShootingEnemies = searchingShootingEnemies;
            _enemyConfig = enemyConfig;
            _bulletView = bulletView;
        }

        public void Initialize()
        {
            _shootingEnemies ??= _searchingShootingEnemies.GetShootingEnemies();
            
            if (_timeInterval <= 0)
                SetNewTime();

            Observable.EveryUpdate().Subscribe(_ =>
            {
                _timeInterval -= Time.deltaTime;

                if (_timeInterval > 0) return;
                
                StartShot();
                SetNewTime();
            })
                .AddTo(_compositeDisposable);
        }

        public void Dispose()
            => _compositeDisposable.Clear();

        private void SetNewTime()
            => _timeInterval = Random.Range(_enemyConfig.MinShotTimeInSec, _enemyConfig.MaxShotTimeInSec);

        private void StartShot()
        {
            var indexEnemy = Random.Range(0, _shootingEnemies.Count);
            
            switch (indexEnemy)
            {
                case 0:
                    for (var i = 0; i < _bulletView.CountBulletsEnemy1; i++)
                    {
                        var bullet = _bulletView.GetBulletsEnemy1(i).gameObject;
                        
                        if (bullet.activeInHierarchy) continue;
                        
                        bullet.transform.position =
                            _shootingEnemies[0][Random.Range(0, _shootingEnemies[0].Count)].position;
                        bullet.SetActive(true);
                        break;
                    }

                    break;
                case 1:
                    for (var i = 0; i < _bulletView.CountBulletsEnemy2; i++)
                    {
                        var bullet = _bulletView.GetBulletsEnemy2(i).gameObject;
                        
                        if (bullet.activeInHierarchy) continue;

                        bullet.transform.position =
                            _shootingEnemies[1][Random.Range(0, _shootingEnemies[1].Count)].position;
                        bullet.SetActive(true);
                        break;
                    }

                    break;
            }
        }
    }
}