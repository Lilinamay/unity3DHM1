using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public GameObject pBox;
    public bool trigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject== pBox)
        {
            trigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == pBox)
        {
            trigger = false;
        }
    }
}
