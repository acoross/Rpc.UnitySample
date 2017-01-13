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
        if (GUI.Button(new Rect(10, 70, 50, 50), "Button"))
        {
            var rpc = GetComponent<MySocket>();
            rpc.Login("acoross", "");
        }
    }
}
