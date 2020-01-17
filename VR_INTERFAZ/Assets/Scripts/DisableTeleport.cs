using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTeleport : MonoBehaviour
{
    public GameObject[] teleports;
    //public GameObject mommy;

    public GameObject MagicDoor;
    public PlayerScript player;
    // Start is called before the first frame update
    void Start()
    {
        EnablePortal(true);
        //mommy.SetActive(false);
        MagicDoor.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //mommy.SetActive(player.control);
    }

    public void EnablePortal(bool input)
    {
        foreach (GameObject tel in teleports)
        {
            tel.SetActive(input); 
        }
    }


    public void PortalActive(bool input)
    {
        MagicDoor.SetActive(input);
    }

}
