using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ARRenderer : MonoBehaviour {

    public VuforiaBehaviour vuforiaBehaviour;
    public RawImage arRenderer;
    public RawImage arFrame;

    protected bool isEnabled = false;

	// Use this for initialization
	void Start () {
        stopAR();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected void enableAR(bool isEnabled)
    {
        vuforiaBehaviour.enabled = arRenderer.enabled = arFrame.enabled = isEnabled;
        this.isEnabled = isEnabled;
    }


    public void stopAR()
    {
        enableAR(false);
       
    }


    public void startAR()
    {
        enableAR(true);
    }

    public void toggleAR()
    {
        enableAR(isEnabled ^ true);
    }

}
