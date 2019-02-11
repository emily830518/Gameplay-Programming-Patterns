﻿using UnityEngine;

[RequireComponent(typeof(Target))]
public class ShootTarget : MonoBehaviour
{
    float fireRate = 1.0f;
    private float nextfire = 0f;
    Rigidbody bulletRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = Resources.Load<Rigidbody>("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        var target = GetComponent<Target>();
        Debug.Assert(target != null);

        if (Time.time > nextfire)
        {
            nextfire = Time.time + fireRate;
            target.position = Utility.GetCharpos();
            target.position.y = transform.position.y;
            var pos = transform.position;
            var shootDir = Utility.GetOffset(pos, target.position).normalized;
            Rigidbody bulletClone = (Rigidbody)Instantiate(bulletRigidbody, transform.position+ shootDir, transform.rotation);
            bulletClone.AddForce(shootDir * 500.0f);
            //bulletClone.velocity = shootDir * 10.0f;
        }
    }

}
