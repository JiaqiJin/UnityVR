using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float lookRadius = 10.0f;
    public int health;
    //public GameObject playerhealth;
    Transform target;
    NavMeshAgent agent;
    private PlayerScript player_;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        player_ = GameObject.Find("Player/TriggerSensor").GetComponent<PlayerScript>();
        health = 120;
        //GameObject
        //agen
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        //playerController = GetComponent<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                //attack
                facceTarget();
            }
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
        {
            Destroy(gameObject);
            player_.HealthLess();
        }
          
        //resta vida al jugador
        //playerController.GetComponent<PlayerController>().health -= 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" )
        {
            Destroy(gameObject);
            player_.HealthLess();
        }

        else if( other.tag == "FireBall")
        {
            health -= 40;
            if(health < 0)
            {
                Destroy(gameObject);
                player_.SumScore();
            }
        }
           
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}
