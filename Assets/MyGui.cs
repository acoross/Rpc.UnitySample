using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGui : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 70, 50, 50), "Login"))
        {
			Debug.Log ("login clicked");
            var rpc = GetComponent<MySocket>();
            bool ok = rpc.Login("acoross", "");
			Debug.Log ("login" + ok.ToString());
        }

		if (GUI.Button(new Rect(10, 130, 50, 50), "Chat"))
		{
			Debug.Log ("chat clicked");
			var rpc = GetComponent<MySocket>();
			rpc.Chat ("unity", "chat");
		}
    }
}
