using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFinalStage : MonoBehaviour
{

    public GameObject[] enemies;
    bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerExit(Collider collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<MeshRenderer>().enabled = activated;

            activated = !activated;

            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<EnemySpawn>().setAttack(activated);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
