using System.Collections;
using System.Collections.Generic;
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
            }
        }

        public void BoolExecution(List<bool> boolList)
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

            Profiler.BeginSample($"For And Foreach - Linq Bool - {boolList.Count}");
            boolList.ForEach(b => Debug.Log($"Value {b}"));
            Profiler.EndSample();
        }

        public void EnemyExecution(List<Enemy> enemyList)
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

            Profiler.BeginSample($"For And Foreach - Linq Enemy - {enemyList.Count}");
            enemyList.ForEach(e => Debug.Log($"Value {e.ToString()}"));
            Profiler.EndSample();
        }
    }
}