using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<EnemyController> listEnemies = new List<EnemyController>();

    public void AddEnemy(EnemyController _enemy)
    {
        if (_enemy == null) return;

        if (!listEnemies.Contains(_enemy))
        {
            listEnemies.Add(_enemy);
        }
    }

    public void RemoveEnemy(EnemyController _enemy)
    {
        if (_enemy == null) return;

        listEnemies.Remove(_enemy);
    }
}
