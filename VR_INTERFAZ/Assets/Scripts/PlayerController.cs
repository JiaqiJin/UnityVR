using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    // GameObjects and create isShooting.
    private GameObject varita;
    private GameObject spawnPoint;
    private bool isShooting;
    
    // Use this for initialization
    void Start()
    {
        

        //create fire and bullet spawnPoint objects
        varita = gameObject.transform.GetChild(0).gameObject;
        spawnPoint = varita.transform.GetChild(0).gameObject;

        //set isShooting bool to default of false
        isShooting = false;
    }

    //Shoot function is IEnumerator so we can delay for seconds
    IEnumerator Shoot()
    {
        //set is shooting to true so we can't shoot continuosly
        isShooting = true;
        //instantiate the bullet
        GameObject bullet = Instantiate(Resources.Load("RangeSpell", typeof(GameObject))) as GameObject;
        //Get the fire's rigid body component and set its position and rotation equal spawnPoint
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        bullet.transform.rotation = spawnPoint.transform.rotation;
        bullet.transform.position = spawnPoint.transform.position;
      
        rb.AddForce(spawnPoint.transform.forward * 500f);
       
        //destroy the bullet after 1 second
        Destroy(bullet, 1);
        //wait for 1 second and set isShooting to false so we can shoot again
        yield return new WaitForSeconds(2f);
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Debug.DrawRay(spawnPoint.transform.position, spawnPoint.transform.forward, Color.green);
        
        //cast a ray from the spawnpoint in the direction of its forward vector
        if (Physics.Raycast(spawnPoint.transform.position, spawnPoint.transform.forward, out hit, 100))
        {
            //Debug.Log(hit);
            if (hit.collider.name.Contains("Enemy") || hit.collider.name.Contains("Mommy"))
            {
                if (!isShooting)
                {
                    StartCoroutine("Shoot");
                }
            }
            
        }

    }
}
