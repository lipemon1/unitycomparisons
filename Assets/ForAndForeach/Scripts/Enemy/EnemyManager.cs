using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ForAndForeach
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField]
        private int enemiesToCreate;

        [SerializeField]
        private EnemyBehavior EnemyPrefab;

        private static List<EnemyBehavior> enemiesOnMap = new List<EnemyBehavior>();
        private static int currentEnemyId;

        // Start is called before the first frame update
        void Start()
        {
            GenerateEnemies();
        }

        private void GenerateEnemies()
        {
            for (int i = 0; i < enemiesToCreate; i++)
            {
                EnemyBehavior enemyBehavior = Instantiate(EnemyPrefab);
                enemyBehavior.StartEnemy(new Enemy(GetNewEnemyId()));

                enemiesOnMap.Add(enemyBehavior);
            }
        }

        public static List<EnemyBehavior> GetAllEnemies()
        {
            return enemiesOnMap;
        }

        public static int GetNewEnemyId()
        {
            int newId = currentEnemyId;
            currentEnemyId++;

            return newId;
        }
    }
}