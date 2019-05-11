using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    static public ARRenderer arRenderer;
    static public GameObject menuDialog;

    static GameManager instance;

    // Use this for initialization
    void Awake () {

        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }


    // Update is called once per frame
    void Update () {
		
	}

}
