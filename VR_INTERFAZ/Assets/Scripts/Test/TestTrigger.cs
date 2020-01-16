using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    Rigidbody rb;
    public float speed;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 20;

    }


}
