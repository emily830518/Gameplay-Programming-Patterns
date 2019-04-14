using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Services
{
    // Enemy Manager   
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

    // Event Manager    
    private static EventManager _event;
    public static EventManager Eventmanager
    {
        get
        {
            Debug.Assert(_event != null);
            return _event;
        }
        set
        {
            _event = value;
        }
    }
}
