using UnityEngine;

[RequireComponent(typeof(Speed), typeof(Target))]
public class ChaseTarget : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var speed = GetComponent<Speed>();
        Debug.Assert(speed != null);

        var target = GetComponent<Target>();
        Debug.Assert(target != null);

        target.position = Utility.GetCharpos();
        target.position.y = transform.position.y;
        var pos = transform.position;
        var offsetToTarget = Utility.GetOffset(pos, target.position);

        Vector3 offset = offsetToTarget.normalized * Time.deltaTime * speed.value;

        var distanceToTarget = offsetToTarget.magnitude;
        offset = Vector3.ClampMagnitude(offset, distanceToTarget);

        transform.position += offset;
    }
}
