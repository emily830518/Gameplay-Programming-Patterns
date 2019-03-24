using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    public float step = 0.2f;
    int changeDirection = 1;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = this.transform.position;
        newPos.x += changeDirection*step;
        if (Mathf.Abs(newPos.x) < 10f && Mathf.Abs(newPos.z) < 10f)
        {
            this.transform.position = newPos;
        }
        else{
            changeDirection = (-1)*changeDirection;
        }
    }
}
