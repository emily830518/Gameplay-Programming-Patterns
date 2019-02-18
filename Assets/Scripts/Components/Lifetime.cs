using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float lifeLeft = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeLeft <= 0)
        {
            Destroy(this);
            gameObject.AddComponent<Disappear>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            lifeLeft--;
    }

}
