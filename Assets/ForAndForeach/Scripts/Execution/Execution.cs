using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Profiling;

namespace ForAndForeach
{
    public class Execution : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                BoolExecution(ListCreator.GetBoolList(10));
                BoolExecution(ListCreator.GetBoolList(100));
                BoolExecution(ListCreator.GetBoolList(1000));
                BoolExecution(ListCreator.GetBoolList(10000));

                EnemyExecution(ListCreator.GetEnemyList(10));
                EnemyExecution(ListCreator.GetEnemyList(100));
                EnemyExecution(ListCreator.GetEnemyList(1000));
                EnemyExecution(ListCreator.GetEnemyList(10000));

                FindFirstEnemy(EnemyManager.GetAllEnemies());
            }
        }

        private void BoolExecution(List<bool> boolList)
        {
            Profiler.BeginSample($"For And Foreach - For Bool - {boolList.Count}");
            for (int i = 0; i < boolList.Count; i++)
            {
                Debug.Log($"Value {boolList[i]}");
            }
            Profiler.EndSample();

            Profiler.BeginSample($"For And Foreach - Foreach Bool - {boolList.Count}");
            foreach (bool value in boolList)
            {
                Debug.Log($"Value {value}");
            }
            Profiler.EndSample();

            Profiler.BeginSample($"For And Foreach - List.Foreach Bool - {boolList.Count}");
            boolList.ForEach(b => Debug.Log($"Value {b}"));
            Profiler.EndSample();
        }

        private void EnemyExecution(List<Enemy> enemyList)
        {
            Profiler.BeginSample($"For And Foreach - For Enemy - {enemyList.Count}");
            for (int i = 0; i < enemyList.Count; i++)
            {
                Debug.Log(enemyList[i].ToString());
            }
            Profiler.EndSample();

            Profiler.BeginSample($"For And Foreach - Foreach Enemy - {enemyList.Count}");
            foreach (Enemy enemy in enemyList)
            {
                Debug.Log(enemy.ToString());
            }
            Profiler.EndSample();

            Profiler.BeginSample($"For And Foreach - Collections Enemy - {enemyList.Count}");
            enemyList.ForEach(e => Debug.Log($"Value {e.ToString()}"));
            Profiler.EndSample();
        }

        private void FindFirstEnemy(List<EnemyBehavior> enemyList)
        {
            Profiler.BeginSample($"For And Foreach - For Enemy - First Enemy IsDead");
            for (int i = 0; i < enemyList.Count; i++)
            {
                if (!enemyList[i].IsDead())
                {
                    Debug.Log($"Enemy Found {i}: {enemyList[i].ToString()}");
                }
            }
            Profiler.EndSample();

            Profiler.BeginSample($"For And Foreach - Foreach Enemy - First Enemy IsDead");
            foreach (EnemyBehavior enemy in enemyList)
            {
                if (!enemy.IsDead())
                {
                    Debug.Log($"Enemy Found: {enemy.ToString()}");
                }
            }
            Profiler.EndSample();

            ForeachEnemyCollections(enemyList);

            Profiler.BeginSample($"For And Foreach - Linq Enemy - First Enemy IsDead");
            Debug.Log($"Enemy Found: {enemyList.Where(e => e.IsDead()).ToString()}");
            Profiler.EndSample();
        }

        private void ForeachEnemyCollections(List<EnemyBehavior> enemyList)
        {
            Profiler.BeginSample($"For And Foreach - Foreach Collections Enemy - First Enemy IsDead");
            enemyList.ForEach(e =>
            {
                if (e.IsDead())
                {
                    Debug.Log($"Enemy Found: {e.ToString()}");
                    Profiler.EndSample();
                    return;
                }
            });
            Profiler.EndSample();
        }
    }
}