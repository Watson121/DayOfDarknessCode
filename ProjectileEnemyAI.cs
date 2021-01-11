using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ProjectileEnemyAI : MonoBehaviour
{

    public enum Projectile_Enemy_Type{
        Ghost,
        Meat_Demon_Eye
    };

    [Header("Enemy Type")]
    public Projectile_Enemy_Type EnemyType;
    [Header("Enemy Parameters")]
    public float WalkingSpeed;
    public float AttackSpeed;
    [Header("Projectile Prefab")]
    public GameObject projectilePrefab;
    public Transform projectileSpawnLocation;

    NavMeshAgent navMesh;
    GameObject player;
    PlayerScript playerScript;

    Director gameDirector;
    Battlenode currentBattlenode;


    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Main Camera");
        playerScript = player.GetComponent<PlayerScript>();

        gameDirector = GameObject.Find("GlobalObj").GetComponent<Director>();
        currentBattlenode = gameDirector.currentBattleNode.GetComponent<Battlenode>();

        if(EnemyType == Projectile_Enemy_Type.Ghost)
        {
            WalkingSpeed = 3.0f;
            AttackSpeed = 10.0f;
        }else if(EnemyType == Projectile_Enemy_Type.Meat_Demon_Eye)
        {
            WalkingSpeed = 0.0f;
            AttackSpeed = 15.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        AttackPlayer();


        navMesh.destination = player.transform.position;
        navMesh.speed = WalkingSpeed;
    }

    void AttackPlayer()
    {
        AttackSpeed -= Time.deltaTime;

        if (AttackSpeed < 0)
        {
            GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnLocation.transform.position, projectileSpawnLocation.transform.rotation);
            currentBattlenode.AddToListOfInteractions(newProjectile);
            AttackSpeed = 4.0f;
        }
    }
}
