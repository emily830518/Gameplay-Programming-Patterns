using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Services
{
    // Enemy Manager System   
    private static EnemyManager _enemy;
    public static EnemyManager Enemymanager
    {
        get
        {
            Debug.Assert(_enemy != null);
            return _enemy;
        }
        set
        {
            _enemy = value;
        }
    }
}
