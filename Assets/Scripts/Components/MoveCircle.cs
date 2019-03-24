using UnityEngine;

public class MoveCircle : MonoBehaviour
{
    float angle = 0;
    float speed = (2 * Mathf.PI) / 3;
    float radius = 8.0f;
    // Update is called once per frame
    void Update()
    {
        angle += speed * Time.deltaTime; //if you want to switch direction, use -= instead of +=
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        this.transform.position = new Vector3(x, 0, y);
    }
}
