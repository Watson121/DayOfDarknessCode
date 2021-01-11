using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{

    GameObject credits;
    GameObject howToPlay;


    // Start is called before the first frame update
    void Start()
    {
        credits = GameObject.Find("Credits");
        howToPlay = GameObject.Find("HowToPlay");

        if(credits) credits.SetActive(false);
        if(howToPlay) howToPlay.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    #region Opening & Closing Scenes

    //These will be used on death screen, pause menu and main menu

    public void LoadFarmLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion

    #region Pause Menu 

    public void ResumeGame()
    {
        //Close Pause Menu, and 
    }

    #endregion

    #region Main Menu

    public void Credits()
    {
        credits.SetActive(!credits.activeSelf);
    }

    public void HowToPlay()
    {
        howToPlay.SetActive(true);
    }

    public void BackToMainMenu()
    {
        howToPlay.SetActive(false);
    }

    public void LoadIntro()
    {
        SceneManager.LoadScene(4);
    }

    #endregion



}
