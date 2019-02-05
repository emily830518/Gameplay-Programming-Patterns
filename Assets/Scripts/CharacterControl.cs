using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {
	public GameObject character;
	public float step = 0.5f;
	public float bulletspeed = 5f;
		
	// Update is called once per frame
	void Update () {
		Vector3 newPos = character.transform.position;
		if (Input.GetKey (KeyCode.RightArrow))
			newPos.x+=step;
		if (Input.GetKey (KeyCode.LeftArrow))
			newPos.x-=step;
		if (Input.GetKey (KeyCode.UpArrow))
			newPos.z+=step;
		if (Input.GetKey (KeyCode.DownArrow))
			newPos.z-=step;
		if(Mathf.Abs(newPos.x) < 10f && Mathf.Abs(newPos.z) < 10f)
			character.transform.position = newPos;
	}
}
