using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMusicTrack : MonoBehaviour
{

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            audioSource.Play();
        }
    }

}
