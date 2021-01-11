using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemyAI : MonoBehaviour
{

    public enum MeleeEnemyType
    {
        Zombie,
        Skeleton
    }

    [Header("Enemy Type")]
    public MeleeEnemyType EnemyType;
    [Header("Enemy Parameters")]
    public float WalkingSpeed;
    public float AttackSpeed;
    public float AttackDamage;

    [Header("Enemy Sounds")]
    public AudioClip zombieGrowl;
    public AudioClip zombieDeath;
    public AudioClip zombieAttack;
    public AudioClip bodyImpact;
    AudioSource enemyAudioSource;


    NavMeshAgent navMesh;
    GameObject player;
    PlayerScript playerScript;
    Animator enemyAnimator;

    GameObject gunshotHitPos;
    bool death;

    // Start is called before the first frame update
    void Start()
    {

        navMesh = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Main Camera");
        playerScript = player.GetComponent<PlayerScript>();

        if(EnemyType == MeleeEnemyType.Zombie)
        {
            WalkingSpeed = 2.0f;
            AttackDamage = 4.0f;
            AttackSpeed = 3.0f;
        }else if (EnemyType == MeleeEnemyType.Skeleton)
        {
            WalkingSpeed = 4.0f;
            AttackDamage = 6.0f;
            AttackSpeed = 3.0f;
        }

        navMesh.destination = player.transform.position;
        navMesh.speed = WalkingSpeed;

        SetRigidbodyState(true);
        SetColliderState(false);

        gunshotHitPos = gameObject.transform.GetChild(2).gameObject;
        enemyAnimator = GetComponent<Animator>();

        enemyAudioSource = GetComponent<AudioSource>();

        death = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (!enemyAudioSource.isPlaying && death == false) PlayZombieGrowl();

        if (GetDistance() < 3.5f && death == false)
        {
            
           
            AttackPlayer();
        }
    }


    float GetDistance()
    {
        return Vector3.Distance(this.gameObject.transform.position, player.transform.position);
    }

    void AttackPlayer()
    {
        enemyAnimator.SetBool("Attack", true);

        AttackSpeed -= Time.deltaTime;

        if(AttackSpeed < 0.5f && !enemyAudioSource.isPlaying) PlayZombieAttack();


        if (AttackSpeed < 0)
        {
          
            playerScript.DecreaseHealth(AttackDamage);
            playerScript.attacked = true;

            if (EnemyType == MeleeEnemyType.Zombie) AttackSpeed = 3.0f;
            else if (EnemyType == MeleeEnemyType.Skeleton) AttackSpeed = 3.0f;
        } else if(AttackSpeed < 2.0f)
        {
            playerScript.attacked = false;
        }
    }

    public void Death()
    {
        death = true;
        enemyAnimator.enabled = false;
        SetRigidbodyState(false);
        SetColliderState(true);

        PlayBodyImpact();
        PlayZombieDeath();


        navMesh.enabled = false;

        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            //rigidbody.AddForce(new Vector3(0.0f, 50.0f, 100.0f), ForceMode.Impulse);

            //Vector3 direction = rigidbody.transform.position - transform.position;

            if(EnemyType == MeleeEnemyType.Zombie) rigidbody.AddForce(transform.forward * - 100, ForceMode.Impulse);
            else if(EnemyType == MeleeEnemyType.Skeleton) rigidbody.AddForce(transform.forward * - 30, ForceMode.Impulse);
        }


    }

    void SetRigidbodyState(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }

        GetComponent<Rigidbody>().isKinematic = !state;

    }

    void SetColliderState(bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach(Collider collider in colliders)
        {
            collider.enabled = state;
        }


        //GetComponent<Collider>().enabled = !state;

    }


    #region Enemy Audio

    public void PlayZombieAttack()
    {
        enemyAudioSource.PlayOneShot(zombieAttack, 0.8f);
    }

    void PlayZombieGrowl()
    {
        enemyAudioSource.PlayOneShot(zombieGrowl, 0.1f);
    }

    void PlayZombieDeath()
    {
        enemyAudioSource.PlayOneShot(zombieDeath, 1.0f);
    }

    void PlayBodyImpact()
    {
        enemyAudioSource.PlayOneShot(bodyImpact, 1.0f);
    }


    #endregion





}
