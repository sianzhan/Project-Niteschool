using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class OpenElevator : MonoBehaviour {
    public GameObject ElevatorRight;
    public GameObject ElevatorLeft;
    public Flowchart flowchart;
    // Use this for initialization
    void Start () {
        Input.multiTouchEnabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount <= 0)
        {
            return;
        }
        if (Input.touchCount == 2)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase==TouchPhase.Moved) //第二個手指 
            {
                Vector3 s1 = Input.GetTouch(0).position;//第一個手指螢幕座標 
                Vector3 s2 = Input.GetTouch(1).position;//第二個手指螢幕座標 
                ElevatorRight.transform.Translate(s1.x * Time.deltaTime * 0.05f , 0, 0);
                ElevatorLeft.transform.Translate(-s2.y * Time.deltaTime * 0.1f , 0, 0);
            }
        }
        if(Mathf.Abs(ElevatorRight.transform.position.x - ElevatorLeft.transform.position.x) > 30)
        {
            flowchart.ExecuteBlock("第二章2");
        }
    }
}
