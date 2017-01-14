using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour {

	public float speed = 1.0f;
	public float rot_speed = 50.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var dt = Time.deltaTime;

		var pos = transform.position;

		var hor = Input.GetAxis ("Horizontal");
		if (Mathf.Epsilon < Mathf.Abs (hor)) {
			transform.Rotate(-1 * hor * Vector3.forward * dt * rot_speed);
		}

		var ver = Input.GetAxis ("Vertical");
		if (Mathf.Epsilon < Mathf.Abs (ver)) {
			
			transform.position = transform.position + transform.up * speed * dt * ver;
		}
			
		if (Input.GetButtonDown ("Fire1")) {
		}
	}
}
