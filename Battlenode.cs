using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Battlenode : MonoBehaviour
{
    public List<GameObject> ListOfInteractions;

    [Header("Spawn Points for enemies")]
    public List<GameObject> ListOfSpawnPoints;
    public List<GameObject> ListOfGhostSpawnPoints;
    public GameObject ContinueInteraction;

    public GameObject currentlyFocusedOn;
    public TypingMechanic typingMechanic;
    public ActivateDecativeTyping activate;
    public int indexNumber;

    private GameObject player;
    private GameObject shotgun;
    private PlayerScript playerScript;
    private ShotgunScript shotgunScript;

    [Header("Battle Node Inputs")]
    public int NumberOfZombiesToSpawn;
    public int NumberOfSkeltonsToSpawn;
    public int NumberOfGhostsToSpawn;
    public float ZombieSpawnTime;
    public float SkeltonSpawnTime;
    public float GhostSpawnTime;

    [SerializeField]
    int NumberOfEnemiesToSpawn;

    [Header("Enemy Prefabs")]
    public GameObject ZombiePrefab;
    public GameObject SkeletonPrefab;
    public GameObject GhostPrefab;

    public float waitTime;


    void Awake()
    {
        indexNumber = 0;

        NumberOfEnemiesToSpawn = NumberOfZombiesToSpawn 
            + NumberOfSkeltonsToSpawn + NumberOfGhostsToSpawn;

        player = GameObject.Find("Main Camera");
        playerScript = player.GetComponent<PlayerScript>();

        shotgun = GameObject.Find("Shotgun");
        shotgunScript = shotgun.GetComponent<ShotgunScript>();

        ContinueInteraction = this.gameObject.transform.GetChild(0).gameObject;

        waitTime = 2.0f;
        //ContinueInteraction.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ListOfInteractions.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) PreviousInteraction();
            if (Input.GetKeyDown(KeyCode.RightArrow)) NextIteraction();
            
        } 
        else if (ListOfInteractions.Count == 0 && NumberOfEnemiesToSpawn == 0)
        {

            ContinueInteraction.SetActive(true);

            if (typingMechanic)
            {

                if (typingMechanic.type_Of_Interaction == TypingMechanic.Type_Of_Interaction.Zombie ||
                  typingMechanic.type_Of_Interaction == TypingMechanic.Type_Of_Interaction.Skeleton
                  || typingMechanic.type_Of_Interaction == TypingMechanic.Type_Of_Interaction.Ghost)
                {
                    waitTime -= Time.deltaTime;

                    if (waitTime < 0)
                    {
                        SetCurrentlyFocused(ContinueInteraction);
                        ContinueInteraction.GetComponent<TypingMechanic>().SetRequiredUIText();
                        waitTime = 2.0f;
                    }
                }
            }
            else
            {
                SetCurrentlyFocused(ContinueInteraction);
                ContinueInteraction.GetComponent<TypingMechanic>().SetRequiredUIText();
            }
        }

        if(NumberOfEnemiesToSpawn > 0)
        {
            SpawnEnemy();
        }

        if (ListOfInteractions.Count == 1)
        {
            indexNumber = 0;
            SetCurrentlyFocused(ListOfInteractions[indexNumber]);
            activate.Activate();
        }

    }

    public void AddToListOfInteractions(GameObject obj)
    {
        ListOfInteractions.Add(obj);       
    }

    public void RemoveFromListOfInteractions(GameObject obj)
    {

            if (currentlyFocusedOn) currentlyFocusedOn.GetComponent<TypingMechanic>().OnWordCompletion();
            ListOfInteractions.Remove(obj);
           

            if (ListOfInteractions.Count > 1)
            {
            PreviousInteraction();
            //waitTime -= Time.deltaTime;

            //if (waitTime < 0)
            //{
            //    PreviousInteraction();
            //    waitTime = 1.0f;
            //}
        }
        
        
    }

    void SpawnEnemy()
    {
        GameObject spawnLocation;

        #region Spawning Zombie

        /*Spawning Zombies*/

        ZombieSpawnTime -= Time.deltaTime;

        if(ZombieSpawnTime < 0 && NumberOfZombiesToSpawn != 0)
        {
            spawnLocation = ListOfSpawnPoints[Random.Range(0, ListOfSpawnPoints.Count - 1)];
            GameObject newZombie = Instantiate(ZombiePrefab, spawnLocation.transform.position, spawnLocation.transform.rotation);
            ZombieSpawnTime = 3.0f;

            AddToListOfInteractions(newZombie);
            NumberOfZombiesToSpawn--;
        }

        #endregion

        #region Spawning Skeltons

        /*Spawning Skeletons into the level*/

        SkeltonSpawnTime -= Time.deltaTime;

        if (SkeltonSpawnTime < 0 && NumberOfSkeltonsToSpawn != 0)
        {
            spawnLocation = ListOfSpawnPoints[Random.Range(0, ListOfSpawnPoints.Count - 1)];
            GameObject newSkeleton = Instantiate(SkeletonPrefab, spawnLocation.transform.position, spawnLocation.transform.rotation);
            SkeltonSpawnTime = 5.0f;

            AddToListOfInteractions(newSkeleton);
            NumberOfSkeltonsToSpawn--;

            Debug.Log("Skelton Spawned");
        }

        #endregion

        #region Spawning Ghosts

        GhostSpawnTime -= Time.deltaTime;

        if (GhostSpawnTime < 0 && NumberOfGhostsToSpawn != 0)
        {
            spawnLocation = ListOfGhostSpawnPoints[Random.Range(0, ListOfGhostSpawnPoints.Count - 1)];
            GameObject newGhost = Instantiate(GhostPrefab, spawnLocation.transform.position, spawnLocation.transform.rotation);
            GhostSpawnTime = 7.0f;

            AddToListOfInteractions(newGhost);
            NumberOfGhostsToSpawn--;

            Debug.Log("Zombie Spawned");
        }


        #endregion

        NumberOfEnemiesToSpawn = NumberOfZombiesToSpawn + NumberOfSkeltonsToSpawn + NumberOfGhostsToSpawn;

       
    }
    
    void NextIteraction()
    {

            //if (indexNumber != ListOfInteractions.Count - 1)
            //{
            //    indexNumber++;
            //}
            //else
            //{
            //    indexNumber = 0;
            //}

        if(indexNumber == ListOfInteractions.Count - 1)
        {
            indexNumber = 0;
        }
        else if(indexNumber < ListOfInteractions.Count - 1)
        {
            indexNumber++;
        }

            activate.Deactivate();
            SetCurrentlyFocused(ListOfInteractions[indexNumber]);
            activate.Activate();
        
    }

    void PreviousInteraction()
    {

            //if (indexNumber != 0)
            //{
            //    indexNumber--;
            //}
            //else
            //{
            //    indexNumber = ListOfInteractions.Count - 1;
            //}

        if(indexNumber == 0)
        {
            indexNumber = ListOfInteractions.Count - 1;
        }else if(indexNumber > 0)
        {
            indexNumber--;
        }

            activate.Deactivate();
            SetCurrentlyFocused(ListOfInteractions[indexNumber]);
            activate.Activate();
      
    }

    void SetCurrentlyFocused(GameObject focusObj)
    {
        if (focusObj)
        {
            currentlyFocusedOn = focusObj;

            typingMechanic = currentlyFocusedOn.GetComponent<TypingMechanic>();

            typingMechanic.battlenode = this;
            activate = currentlyFocusedOn.GetComponent<ActivateDecativeTyping>();

            if (typingMechanic.type_Of_Interaction == TypingMechanic.Type_Of_Interaction.Zombie || 
                typingMechanic.type_Of_Interaction == TypingMechanic.Type_Of_Interaction.Skeleton
                || typingMechanic.type_Of_Interaction == TypingMechanic.Type_Of_Interaction.Ghost) {
                playerScript.SetLookAtObj(currentlyFocusedOn.transform.GetChild(3).gameObject);
                shotgunScript.SetCurrentEnemy(currentlyFocusedOn.transform.GetChild(3).gameObject);
            }
            else
            {
                playerScript.SetLookAtObj(currentlyFocusedOn.transform.gameObject);
                shotgunScript.SetCurrentEnemy(currentlyFocusedOn.transform.gameObject);
            }
        }
    }
}
