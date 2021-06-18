using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ForAndForeach
{
    public static class ListCreator
    {
        public static List<bool> GetBoolList(int sizeWanted)
        {
            List<bool> boolList = new List<bool>();

            for (int i = 0; i < sizeWanted; i++)
            {
                boolList.Add(Random.Range(0, 1) == 0 ? true : false);
            }

            return boolList;
        }

        public static List<Enemy> GetEnemyList(int sizeWanted)
        {
            List<Enemy> enemyList = new List<Enemy>();

            for (int i = 0; i < sizeWanted; i++)
            {
                enemyList.Add(new Enemy(EnemyManager.GetNewEnemyId()));
            }

            return enemyList;
        }
    }
}