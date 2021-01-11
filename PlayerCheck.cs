using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{

    public bool PlayerIsAtNode;
    public Battlenode battlenode;

    // Update is called once per frame

    private void Start()
    {
        battlenode = GetComponent<Battlenode>();
    }

    void Update()
    {
        battlenode.enabled = PlayerIsAtNode;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerIsAtNode = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerIsAtNode = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerIsAtNode = false;
        }
    }


}
