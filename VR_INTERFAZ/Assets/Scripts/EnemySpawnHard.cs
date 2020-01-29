using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawnHard : EnemyHard
{


    public GameObject tomb;

    private Transform spawnpoint;



   

    void Start()
    {
        health = maxHealth;
        //GameObject
        //agen
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        player_ = GameObject.Find("Player/TriggerSensor").GetComponent<PlayerScript>();
        spawnpoint = tomb.transform;
        //playerController = GetComponent<PlayerController>().gameObject;
    }



    private void respawnOnSpawnPoint()
    {
        health = maxHealth;
        this.transform.position = spawnpoint.position;
    }

    private void randomRespawn(GameObject gameObject)
    {
      //  GameObject this = gameObject;
        health = maxHealth;

        //set the coordinates for a new vector 3
        float randomX = UnityEngine.Random.Range(-10f, 10f);
        float constantY = .01f;
        float randomZ = UnityEngine.Random.Range(-10f, 10f);
        //set the mami position equal to these new coordinates
        this.transform.position = new Vector3(randomX + (spawnpoint.position.x - 3.0f), constantY, randomZ + (spawnpoint.position.z - 3.0f));

        //si la mami se posiciona a menos o igual a 7 unidades de escena de la cámara, no podremos dispararle
        //así que sigue reubicando a la mamá hasta que esté a más de 3 unidades de escena.
        while (Vector3.Distance(this.transform.position, Camera.main.transform.position) <= 10)
        {

            randomX = UnityEngine.Random.Range(-10f, 10f);
            randomZ = UnityEngine.Random.Range(-10f, 10f);

            this.transform.position = new Vector3(randomX + (target.position.x - 5.0f), constantY, randomZ + (target.position.z - 5.0f));

        }
    }

    protected void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            respawnOnSpawnPoint();
            player_.HealthLess();
        }

        //resta vida al jugador
        //playerController.GetComponent<PlayerController>().health -= 10;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player_.HealthLess();
            respawnOnSpawnPoint();

        }
        else if (other.tag == "FireBall")
        {
            attack = true;
            health -= 40;
            if (health < 0)
            {
  
                player_.SumScore();

                respawnOnSpawnPoint();

            }         

        }       

    }


}

