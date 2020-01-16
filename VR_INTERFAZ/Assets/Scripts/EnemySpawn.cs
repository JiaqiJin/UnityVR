using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawn : MonoBehaviour
{

    public float lookRadius = 10.0f;
    public int health;
    //public GameObject playerhealth;
    Transform target;
    private Transform spawnpoint;
    NavMeshAgent agent;
    int count = 0;
    private PlayerScript player_;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        health = 120;
        //GameObject
        //agen
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        player_ = GameObject.Find("Player/TriggerSensor").GetComponent<PlayerScript>();
        spawnpoint = GameObject.Find("SpwainPoint").transform;
        //playerController = GetComponent<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
       
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                //attack
                facceTarget();
            }

        //scoreText.text = count.ToString();
    }

    void facceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
            Destroy(gameObject);
        
        //resta vida al jugador
        //playerController.GetComponent<PlayerController>().health -= 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            GameObject mommy = Instantiate(Resources.Load("Mommy", typeof(GameObject))) as GameObject;

            //set the coordinates for a new vector 3
            float randomX = UnityEngine.Random.Range(-10f, 10f);
            float constantY = .01f;
            float randomZ = UnityEngine.Random.Range(-10f, 10f);
            //set the mami position equal to these new coordinates
            mommy.transform.position = new Vector3(randomX + (spawnpoint.position.x - 3.0f), constantY, randomZ + (spawnpoint.position.z - 3.0f));

            //si la mami se posiciona a menos o igual a 3 unidades de escena de la cámara, no podremos dispararle
            //así que sigue reubicando a la mamá hasta que esté a más de 3 unidades de escena.
            while (Vector3.Distance(mommy.transform.position, Camera.main.transform.position) <= 3)
            {

                randomX = UnityEngine.Random.Range(-10f, 10f);
                randomZ = UnityEngine.Random.Range(-10f, 10f);

                mommy.transform.position = new Vector3(randomX + (target.position.x - 3.0f), constantY, randomZ + (target.position.z - 3.0f));

            }

        }
        else if (other.tag == "FireBall")
        {
            health -= 40;
            if (health < 0)
            {
                Destroy(gameObject);
                //suma un punto al jugador
                player_.SumScore();

                GameObject mommy = Instantiate(Resources.Load("Mommy", typeof(GameObject))) as GameObject;

                //set the coordinates for a new vector 3
                float randomX = UnityEngine.Random.Range(-10f, 10f);
                float constantY = .01f;
                float randomZ = UnityEngine.Random.Range(-10f, 10f);
                //set the mami position equal to these new coordinates
                mommy.transform.position = new Vector3(randomX + (spawnpoint.position.x - 3.0f), constantY, randomZ + (spawnpoint.position.z - 3.0f));

                //si la mami se posiciona a menos o igual a 3 unidades de escena de la cámara, no podremos dispararle
                //así que sigue reubicando a la mamá hasta que esté a más de 3 unidades de escena.
                while (Vector3.Distance(mommy.transform.position, Camera.main.transform.position) <= 3)
                {

                    randomX = UnityEngine.Random.Range(-10f, 10f);
                    randomZ = UnityEngine.Random.Range(-10f, 10f);

                    mommy.transform.position = new Vector3(randomX + (target.position.x - 3.0f), constantY, randomZ + (target.position.z - 3.0f));

                }
            }         

        }       

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}

