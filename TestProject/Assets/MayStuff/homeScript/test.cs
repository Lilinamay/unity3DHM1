using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float x = 0;
    public float y = 0;
    public float z = 0;
    public Vector3 target;
    public Vector3 pos;
    public Vector3 space;
    public float curTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curTime = Mathf.Clamp(curTime + Time.deltaTime, 0.0f, 0.5f);
        transform.position = Vector3.Lerp(pos, target-space, curTime/0.5f);

        if (curTime >= 0.5f)
        {
            enabled = false;
            curTime = 0;
        }
    }
}
