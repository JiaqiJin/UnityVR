using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    public float spinForce;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, 1+ Time.deltaTime, 0);
        //transform.rotation = Quaternion.Euler(new Vector3(0, spinForce * Time.deltaTime , 0));
    }

    public void ChangeSpin()
    {
        spinForce = -spinForce;
    }


}
