using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour
{
    public int point; // varibale para alamcenar monedas
    public int health;
    public int score;
    public Text healtText;
    public Text scoreText;
    public Text pointsText;
    public bool control;
   /* public int getScore
    {
        get
        {
            return score;
        }
    }*/

    public void SumScore()
    {
        score++;
    }

    public void HealthLess()
    {
        health -= 10;
    }

    public DisableTeleport dis;

    private void Start()
    {
        health = 100;
        healtText.text = health.ToString();
        scoreText.text = score.ToString();
        pointsText.text = point.ToString();
    }

    private void Update()
    {
        control = false;
        healtText.text = health.ToString();
        scoreText.text = score.ToString();
        pointsText.text = point.ToString();
        //12 && point > 8
        if (score >= 12 && point > 8)
        {
            dis.GetComponent<DisableTeleport>().EnablePortal(true);
            //dis.GetComponent<DisableTeleport>().PortalActive(true);
           
        }

        if(health <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        point+=1;

        if (other.tag == "Coins")
            point += 5;

        else if (other.tag == "Enemy")
        {
            health -= 10;
        }

        else if(other.tag == "Fight")
        {           
            dis.GetComponent<DisableTeleport>().EnablePortal(false);
            control = true;
            //Debug.Log(control);
            //dis.GetComponent<DisableTeleport>().MommyActive(true);
        }
    }
}
