using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyManager Manager { get; set; }
    //public static bool isAlive;
    //Start is called before the first frame update
    void Start()
    {
        //isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonUp(0))
        //{
        //    CreateEntity();
        //}
        if(GetComponent<Disappear>().readyToBeDestroyed == false)
            Manager.Destroy(this);
    }

    public static void CreateEntity(GameObject go)
    {
        //var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ////go.tag = "Enemy";
        ////generate enemy at random position on the X-Z plane
        Vector3 pos = new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, Random.Range(0.0f, 10.0f));
        go.transform.position = pos;

        go.AddComponent<Lifetime>();
        int enemytype=AddRandomComponent(go);
        if (enemytype == 0)
        {
            go.GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (enemytype == 1)
        {
            go.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            go.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

    private static int AddRandomComponent(GameObject go)
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
            go.AddComponent(typeof(ChaseTarget));
            go.AddComponent(typeof(ShootTarget));
        }
        return type;
    }

    //public void DestroyEntity(){
    //    Manager.Destroy(this);
    //}
}
