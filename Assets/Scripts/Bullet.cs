using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	float speed = 10f;
	float existTime = 1.5f;
		
	// Update is called once per frame
	void Update () {
		this.transform.Translate (0, 0, speed * Time.deltaTime);
		Destroy (gameObject, existTime);
	}
}
