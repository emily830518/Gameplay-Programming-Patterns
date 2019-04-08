using System;
using UnityEngine;

public static class Utility
{
    public static T GetRandomElement<T>(T[] array)
    {
        Debug.Assert(array.Length > 0);
        var i = UnityEngine.Random.Range(0, array.Length);
        return array[i];
    }

    public static Vector3 GetOffset(Vector3 from, Vector3 to)
    {
        return to - from;
    }

    public static Vector3 GetCharpos()
    {
        return GameObject.Find("MainCharacter").transform.position;
    }

    public static int GetPlayerLives()
    {
        return GameObject.Find("MainCharacter").GetComponent<Player>().lives;
    }

}
