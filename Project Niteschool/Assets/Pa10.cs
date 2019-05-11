using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pa10 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0f, 0.866f, 0.5f), Time.deltaTime * 60);
    }
}
