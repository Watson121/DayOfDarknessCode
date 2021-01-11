using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    public enum Projectile_Type
    {
        GhostProjectile,
        MeatDemonProjectile
    };

    [Header("Projectile Type")]
    public Projectile_Type ProjectileType;

    [Header("Projectile Speed")]
    public float speed = 0.1f;

    GameObject playerObj;
    PlayerScript playerScript;

    float playerDamage;

    private void Awake()
    {
        playerObj = GameObject.Find("Main Camera");
        playerScript = playerObj.GetComponent<PlayerScript>();

        if (ProjectileType == Projectile_Type.GhostProjectile) playerDamage = 6.0f;
        else if (ProjectileType == Projectile_Type.MeatDemonProjectile) playerDamage = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerObj.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Hit Player");
            playerScript.DecreaseHealth(playerDamage);
        }
    }


}
