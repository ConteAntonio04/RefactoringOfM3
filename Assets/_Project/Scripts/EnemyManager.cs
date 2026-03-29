using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<EnemyController> listEnemies = new List<EnemyController>();

    public void AddEnemy(EnemyController enemy)
    {
        if (enemy == null) return;

        if (!listEnemies.Contains(enemy))
        {
            listEnemies.Add(enemy);
        }
    }

    public void RemoveEnemy(EnemyController enemy)
    {
        if (enemy == null) return;

        listEnemies.Remove(enemy);
    }
}
