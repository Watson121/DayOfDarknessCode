using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour
{

    Animator shotgunAnimator;
    GameObject currentEnemy;
    public float waitTime = 1.0f;
    bool fired;

    ParticleSystem pellets;
    ParticleSystem sparks;
    ParticleSystem smoke;


    // Start is called before the first frame update
    void Start()
    {
        shotgunAnimator = GetComponent<Animator>();

        pellets = GameObject.Find("Pellets").GetComponent<ParticleSystem>();
        sparks = GameObject.Find("Sparks").GetComponent<ParticleSystem>();
        smoke = GameObject.Find("Smoke").GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        if(currentEnemy) this.transform.LookAt(currentEnemy.transform, Vector3.up);

        if(fired == true)
        {
            waitTime -= Time.deltaTime;

            if (waitTime < 0)
            {
                shotgunAnimator.SetBool("Fire", false);
                waitTime = 1.0f;
                fired = false;
            }
        }
    }

    public void SetCurrentEnemy(GameObject obj)
    {
        currentEnemy = obj;
    }

    public void ShotgunFire()
    {
        if (shotgunAnimator) {
            shotgunAnimator.SetBool("Fire", true);

            pellets.Play();
            sparks.Play();
            smoke.Play();

            fired = true;       
        }
    }

    public void ShotgunRun(bool state)
    {
        if (shotgunAnimator)
        {
            shotgunAnimator.SetBool("Running", state);
        }
    }


}
