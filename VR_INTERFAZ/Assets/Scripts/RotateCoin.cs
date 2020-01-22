using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{

    public float speed = 70;

    void Update()
    {
   
            transform.Rotate(Time.deltaTime *speed, 0, 0, Space.Self);
   

    }
}