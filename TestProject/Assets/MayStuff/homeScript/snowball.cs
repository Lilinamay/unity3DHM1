using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowball : MonoBehaviour
{
    private Rigidbody snowbody;
    // Start is called before the first frame update
    private void Awake()
    {
        snowbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        float speed = 20f;
        snowbody.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
