using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGui : MonoBehaviour {

	// Use this for initialization
	void Start () {
		characterDictionary = new Dictionary<int, GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject characterPreFab;
	Dictionary<int, GameObject> characterDictionary;
	int id = 0;

    void OnGUI()
    {
		if (GUI.Button (new Rect (10, 70, 50, 50), "Login")) {
			Debug.Log ("login clicked");
			var rpc = GetComponent<MySocket> ();
			bool ok = rpc.Login ("acoross", "");
			Debug.Log ("login" + ok.ToString ());
		}

		if (GUI.Button (new Rect (10, 130, 50, 50), "Chat")) {
			Debug.Log ("chat clicked");
			var rpc = GetComponent<MySocket> ();
			rpc.Chat ("unity", "chat");
		}

		if (GUI.Button (new Rect (10, 190, 50, 50), "SpawnNew")) {
			Debug.Log ("SpawnNew clicked");
			var obj = Instantiate (characterPreFab, new Vector3 (0, 0), Quaternion.identity);
			characterDictionary.Add (id++, obj);
		}
    }
}
