using UnityEngine;

public class Bullets : MonoBehaviour
{
    float existTime = 5.0f;

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, existTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
