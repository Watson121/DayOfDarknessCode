using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour
{

    PlayerScript playerScript;


    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Main Camera").GetComponent<PlayerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerScript.IncreaseHealth(20.0f);
            Debug.Log("Hello");
        }
    
    }


}
