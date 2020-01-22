using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float lookRadius = 10.0f;
    public int health;

    protected Transform target;
    protected NavMeshAgent agent;
    protected PlayerScript player_;

    public float wanderRadius = 5;
    public float wanderTimer = 3f;

    protected float timer = 0;
    public bool attack = false;
    public int maxHealth = 120;

    // Start is called before the first frame update
    void Start()
    {
        player_ = GameObject.Find("Player/TriggerSensor").GetComponent<PlayerScript>();
        health = maxHealth;
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

        if(distance <= lookRadius || attack)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                //attack
                facceTarget();
            }
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }
        }

        //scoreText.text = count.ToString();
    }

    public void setAttack(bool input)
    {
        attack = input;
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }


   protected void facceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    protected void OnCollisionEnter(Collision collision)
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

    protected void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" )
        {
            Destroy(gameObject);
            player_.HealthLess();
        }

        else if( other.tag == "FireBall")
        {
            attack = true;
            health -= 40;
            if(health < 0)
            {
                Destroy(gameObject);
                player_.SumScore();
            }
        }
           
    }

    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}
