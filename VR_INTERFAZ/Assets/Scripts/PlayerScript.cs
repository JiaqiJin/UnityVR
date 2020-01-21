using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour
{
    public int maxHealth;
    public int pointsObjetive;
    public int scoreObjetive;
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
        scoreObjetive = 12;
        pointsObjetive = 8;
        maxHealth = 100;

        health = maxHealth;
        healtText.text = health.ToString();
        scoreText.text = score.ToString() + "/" + scoreObjetive;
        pointsText.text = point.ToString() + "/" + pointsObjetive;
    }

    private void Update()
    {
        control = false;
        healtText.text = health.ToString();
        scoreText.text = score.ToString() + "/" + scoreObjetive;
        pointsText.text = point.ToString() + "/" + pointsObjetive;
        //12 && point > 8
        if (score >= scoreObjetive && point >= pointsObjetive)
        {
            dis.GetComponent<DisableTeleport>().EnablePortal(true);
           
        }

        if(health <= 0)
        {
            SceneManager.LoadScene("Lose");
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
