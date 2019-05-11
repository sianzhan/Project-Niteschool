using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class OpenElevator : MonoBehaviour {
    public GameObject ElevatorRight;
    public GameObject ElevatorLeft;
    public Flowchart flowchart;

    Vector3 motoPosRight;
    Vector3 motoPosLeft;

    float motoTouchShift = 0;

    float touchShift;

    float shiftRight;
    float shiftLeft;

    public float mulTouch = 0.25f;
    public float mulAccel = 40f;
    public float thresholdUntilOpen = 200;

    float accumulator = 0;
    // Use this for initialization
    void Start () {
        accumulator = 0;
        Input.multiTouchEnabled = true;
        motoPosRight = ElevatorRight.transform.position;
        motoPosLeft = ElevatorLeft.transform.position;
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        shiftLeft = 0;
        shiftRight = 0;
        if(Input.anyKeyDown)
        {
            accumulator += thresholdUntilOpen / 10;
        }
        else if (Input.touchCount == 2)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved) //第二個手指 
            {
                Vector3 s1 = Input.GetTouch(0).position;//第一個手指螢幕座標 
                Vector3 s2 = Input.GetTouch(1).position;//第二個手指螢幕座標 

                touchShift = Mathf.Abs(s1.x - s2.x) * Time.deltaTime;

                shiftLeft = touchShift * mulTouch;
                shiftRight = touchShift * mulTouch;

                motoTouchShift = touchShift;
            }else
            {
                motoTouchShift = 0;
            }
        }
        float accelX = Mathf.Abs(Input.gyro.userAcceleration.x);
        shiftLeft += accelX * Time.deltaTime * mulAccel;
        shiftRight += accelX * Time.deltaTime * mulAccel;

        if (shiftLeft < 0) shiftLeft = 0;
        if (shiftRight < 0) shiftRight = 0;

        accumulator += shiftLeft + shiftLeft;

        ElevatorRight.transform.Translate(shiftRight, 0, 0);
        ElevatorLeft.transform.Translate(-shiftLeft, 0, 0);

        ElevatorRight.transform.position = Vector3.Lerp(ElevatorRight.transform.position, motoPosRight, 0.3f);
        ElevatorLeft.transform.position = Vector3.Lerp(ElevatorLeft.transform.position, motoPosLeft, 0.3f);

        if(accumulator > thresholdUntilOpen)
        {
            ElevatorLeft.transform.localPosition = new Vector3(-4, ElevatorLeft.transform.localPosition.y);
            ElevatorLeft.transform.rotation = Quaternion.Euler(0, 0, -4);
            ElevatorRight.transform.localPosition = new Vector3(4, ElevatorRight.transform.localPosition.y);
            ElevatorRight.transform.rotation = Quaternion.Euler(0, 0, 6);
            flowchart.ExecuteBlock("電梯壞了");
        }
        else if (Mathf.Abs(ElevatorRight.transform.position.x - ElevatorLeft.transform.position.x) > 40)
        {
            flowchart.ExecuteBlock("第二章2");
        }
    }
}
