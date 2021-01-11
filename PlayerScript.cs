using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour
{
    [Header("Player Audio Source")]
    public AudioSource audioSource;

    [Header("Audio Clips")]
    public AudioClip typeWriterKeyPress;
    public AudioClip shotgunFire;
    public AudioClip typeWritingMultiplePresses;
    public AudioClip typeWriterDing;
    public AudioClip running;
    public AudioClip playerGrunt;

    public GameObject mainCamera;
    public bool moving;
    [SerializeField]
    GameObject lookAtObj;

    [SerializeField]
    float playerHealth;
    int playerLives;

    #region UI

    [SerializeField]
    TextMeshProUGUI playerHealthNumber;

    #endregion

    GameObject globalObj;
    GameObject player;
    Director gameDirector;
    [SerializeField]
    GameObject currentBattleNode;

    //Player Shotgun
    GameObject shotgun;
    ShotgunScript shotgunScript;


    //Player Navigation
    [SerializeField]
    NavMeshAgent playerNavAgent;

    //Post Processing
    PostProcessVolume postProcessVolume;
    Vignette playerVingette;
    [SerializeField]
    float vingetteValue;

    public bool attacked;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = this.gameObject;
        playerHealth = 100;
        playerLives = 3;

        #region Finding Player Componenets

        audioSource = GetComponent<AudioSource>();
        playerNavAgent = GameObject.Find("Player").GetComponent<NavMeshAgent>();
       
        shotgun = GameObject.Find("Shotgun");
        shotgunScript = shotgun.GetComponent<ShotgunScript>();

        #endregion

        #region Post Processing

        postProcessVolume = GetComponent<PostProcessVolume>();

        postProcessVolume.profile.TryGetSettings(out playerVingette);

        playerVingette.enabled.value = true;

        vingetteValue = 0.0f;

        #endregion



        #region Finidng UI Elements

        playerHealthNumber = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();

        #endregion

        #region Finding Game Director & Battlenode

        globalObj = GameObject.Find("GlobalObj");
        player = GameObject.Find("Player");
        gameDirector = globalObj.GetComponent<Director>();
        currentBattleNode = gameDirector.currentBattleNode;

        #endregion

    }

    private void Update()
    {

        if (lookAtObj && GetDistance() < 3)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, GetAngleLookAtObj() , 2.0f * Time.deltaTime);
        }
        if (moving)
        {
            playerNavAgent.speed = 5.5f;
            TransformToNewNode();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(0);

        DamageVingette();
        PlayerHealthCheck();
    }

    Quaternion GetAngleLookAtObj()
    {

        Vector3 pos = lookAtObj.transform.position - transform.position;

        return Quaternion.LookRotation(pos, Vector3.up);
    }

    #region Player Audio
    public void PlayTypeWritingKeySound()
    {
        audioSource.PlayOneShot(typeWriterKeyPress, 0.8f);
    }

    public void PlayTypewritingDing()
    {
        audioSource.PlayOneShot(typeWriterDing, 1.0f);
    }

    public void PlayTypeWriterMultipleHits()
    {
        audioSource.PlayOneShot(typeWritingMultiplePresses, 1.0f);
    }

    public void PlayerShotgunSound()
    {
       audioSource.PlayOneShot(shotgunFire, 0.6f);
    }

    public void PlayRunningSound()
    {
        audioSource.PlayOneShot(running, 0.5f);
    }

    public void PlayerGrunt()
    {
        audioSource.PlayOneShot(playerGrunt, 0.5f);
    }


    #endregion

    public void SetLookAtObj(GameObject obj)
    {
        lookAtObj = obj;
    }

    float GetDistance()
    {
        return Vector3.Distance(this.gameObject.transform.position, player.transform.position);
    }


    public void TransformToNewNode()
    {
        currentBattleNode = gameDirector.currentBattleNode;
        lookAtObj = null;

        playerNavAgent.destination = currentBattleNode.transform.position;

        shotgunScript.ShotgunRun(true);

        lookAtObj = currentBattleNode;

        float distance = Vector3.Distance(this.gameObject.transform.position, currentBattleNode.transform.position);

        if(!audioSource.isPlaying) PlayRunningSound();

        if (distance < 2.0)
        {
            audioSource.Stop();
            moving = false;
            shotgunScript.ShotgunRun(false);
        }

    }

    #region PlayerHealth
    public void DecreaseHealth(float Damage)
    {
        playerHealth -= Damage;
        vingetteValue = 0.4f;
        PlayerGrunt();
    }

    public void IncreaseHealth(float Health)
    {
        playerHealth += Health;
        if (playerHealth > 100) playerHealth = 100;
    }

    void PlayerHealthCheck()
    {

        playerHealthNumber.SetText(playerHealth.ToString());
        //playerLivesNumber.SetText(playerLives.ToString());

        if (playerHealth <= 0)
        {
            Debug.Log("End Game");
            SceneManager.LoadScene(2);
        }

    }

    #endregion

    void DamageVingette()
    {
        //if(attacked) playerVingette.intensity.value = Mathf.Lerp(playerVingette.intensity.value, 0.5f, 10.0f * Time.deltaTime);
        //else if(!attacked) playerVingette.intensity.value = Mathf.Lerp(playerVingette.intensity.value, 0.0f, 10.0f * Time.deltaTime);


        //if(playerVingette.intensity.value != 0.5) playerVingette.intensity.value = Mathf.Lerp(playerVingette.intensity.value, vingetteValue, 10.0f * Time.deltaTime);
        //else
        //{
        //    vingetteValue = 0;
        //    playerVingette.intensity.value = Mathf.Lerp(playerVingette.intensity.value, vingetteValue, 10.0f * Time.deltaTime);
        //}

    }




}
