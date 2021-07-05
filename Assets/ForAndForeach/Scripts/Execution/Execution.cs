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

                FirstDeadEnemy(EnemyManager.GetAllEnemies());
                AllDeadEnemies(EnemyManager.GetAllEnemies());
            }
        }

        private void BoolExecution(List<bool> boolList)
        {
            Profiler.BeginSample($"For And Foreach - For Bool - {boolList.Count}");
            for (int i = 0; i < boolList.Count; i++)
            {
                Debug.Log($"Value: {boolList[i]}");
            }
            Profiler.EndSample();

            Profiler.BeginSample($"For And Foreach - Foreach Bool - {boolList.Count}");
            foreach (bool value in boolList)
            {
                Debug.Log($"Value: {value}");
            }
            Profiler.EndSample();

            Profiler.BeginSample($"For And Foreach - List.Foreach Bool - {boolList.Count}");
            boolList.ForEach(v => Debug.Log($"Value {v}"));
            Profiler.EndSample();
        }

        private void EnemyExecution(List<Enemy> enemyList)
        {
            Profiler.BeginSample($"For And Foreach - For Enemy - {enemyList.Count}");
            for (int i = 0; i < enemyList.Count; i++)
            {
                Debug.Log($"Value: {enemyList[i]}");
            }
            Profiler.EndSample();

            Profiler.BeginSample($"For And Foreach - Foreach Enemy - {enemyList.Count}");
            foreach (Enemy enemy in enemyList)
            {
                Debug.Log($"Value: {enemy}");
            }
            Profiler.EndSample();

            Profiler.BeginSample($"For And Foreach - List.Foreach Enemy - {enemyList.Count}");
            enemyList.ForEach(e => Debug.Log($"Value {e}"));
            Profiler.EndSample();
        }

        private void FirstDeadEnemy(List<EnemyBehavior> enemyList)
        {
            Profiler.BeginSample($"For And Foreach - For Enemy - First Dead Enemy");
            for (int i = 0; i < enemyList.Count; i++)
            {
                if (enemyList[i].IsDead())
                {
                    Debug.Log($"Enemy Found: {enemyList[i]}");
                    break;
                }
            }
            Profiler.EndSample();

            Profiler.BeginSample($"For And Foreach - Foreach Enemy - First Dead Enemy");
            foreach (EnemyBehavior enemy in enemyList)
            {
                if (enemy.IsDead())
                {
                    Debug.Log($"Enemy Found: {enemy}");
                    break;
                }
            }
            Profiler.EndSample();

            Profiler.BeginSample($"For And Foreach - List.FirstOrDefault - First Dead Enemy");
            Debug.Log($"Enemy Found: {enemyList.FirstOrDefault(e => e.IsDead())}");
            Profiler.EndSample();
        }

        private void AllDeadEnemies(List<EnemyBehavior> enemyList)
        {
            Profiler.BeginSample($"For And Foreach - For Enemy - All Dead Enemies");
            for (int i = 0; i < enemyList.Count; i++)
            {
                if (enemyList[i].IsDead())
                {
                    Debug.Log($"Enemy Found: {enemyList[i]}");
                }
            }
            Profiler.EndSample();

            Profiler.BeginSample($"For And Foreach - Foreach Enemy - All Dead Enemies");
            foreach (EnemyBehavior enemy in enemyList)
            {
                if (enemy.IsDead())
                {
                    Debug.Log($"Enemy Found: {enemy}");
                }
            }
            Profiler.EndSample();

            Profiler.BeginSample($"For And Foreach - List.Foreach Enemy - All Dead Enemies");
            enemyList.ForEach(e =>
            {
                if (e.IsDead())
                {
                    Debug.Log($"Enemy Found: {e}");                    
                }
            });
            Profiler.EndSample();

            Profiler.BeginSample($"For And Foreach - List.Where.ToList.ForEach Enemy - All Dead Enemies");
            enemyList.Where(e => e.IsDead()).ToList().ForEach(e =>
            {
                Debug.Log($"Enemy Found: {e}");
            });
            Profiler.EndSample();
        }
    }
}