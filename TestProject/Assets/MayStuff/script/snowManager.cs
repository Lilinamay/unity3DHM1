using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowManager : MonoBehaviour
{
    public bool hitEnemy = false;
    public bool startTimer = false;
    public bool go = false;
    public float Timer;
    public float maxTime = 5f;
    public GameObject enemy;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (startTimer)
        {
            Timer = maxTime;
            startTimer = false;
        }
        if (Timer > 0)
        {
            hitEnemy = true;
            Timer -= Time.deltaTime;
        }
        else if (Timer <= 0)
        {
            hitEnemy = false;
            go = false;
        }

        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    player.transform.position = enemy.transform.position;
        //}
    }
}
