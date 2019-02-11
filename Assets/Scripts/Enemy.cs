//using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            CreateEntity();
        }
    }

    private static void CreateEntity()
    {
        var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //generate enemy at random position on the X-Z plane
        Vector3 pos = new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, Random.Range(-10.0f, 10.0f));
        go.transform.position = pos;
        AddRandomComponent(go);
        //go.AddComponent(typeof(ControlledByKeyboard));
        //go.AddComponent(typeof(ChaseTarget));
        //go.AddComponent(typeof(ShootTarget));

    }

    private static void AddRandomComponent(GameObject go)
    {
        int type = Random.Range(0, 3);
        if (type == 0)
        {
            go.AddComponent(typeof(ChaseTarget));
        }
        else if (type == 1)
        {
            go.AddComponent(typeof(ShootTarget));
        }
        else
        {
            go.AddComponent(typeof(ControlledByKeyboard));
            go.AddComponent(typeof(ShootTarget));
        }
    }
}
