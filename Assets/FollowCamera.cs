using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

	public GameObject playerObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var player = playerObject.transform.position;
		transform.position = new Vector3 (player.x, player.y, transform.position.z);
	}
}
