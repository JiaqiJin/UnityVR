using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VRTeleport : MonoBehaviour
{
    public Image imageCircle;

    public float totalTime = 0.7f;
    bool gvrStatus;
    float gvrTimer;

    public int distanceOfRay = 20;
    private RaycastHit hit_;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imageCircle.fillAmount = gvrTimer / totalTime;
        } 

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0f));

        if(Physics.Raycast(ray , out hit_ , distanceOfRay))
        {
            if(imageCircle.fillAmount == 1 && hit_.transform.CompareTag("Teleport"))
            {
                hit_.transform.gameObject.GetComponent<Teleport>().TeleportPlayer();
            }

            if (hit_.transform.CompareTag("PortaL") && imageCircle.fillAmount == 1)
            {
                SceneManager.LoadScene("Win");
            }
        }

    }

    public void GVROn()
    {
        gvrStatus = true;
    }

    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imageCircle.fillAmount = 0;

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.DrawRay(collision.contacts[0].point, collision.contacts[0].normal, Color.green, 2, false);
    }
}
