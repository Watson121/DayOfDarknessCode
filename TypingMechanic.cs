using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypingMechanic : MonoBehaviour
{
    #region Enums for different types of interactions

    /* A list of enums for all of the different types of interactions. Different interactions 
     * means a different set of word pools*/

    public enum Type_Of_Interaction
    {
        Zombie,
        Skeleton,
        Ghost,
        Final_Boss,
        Health_PickUp,
        Slow_Down_Time,
        TwoTimes_Points,
        OpenDoor,
        SmashDoor,
        Torch,
        Continue,
        Projectile
    };

    #endregion

    public Type_Of_Interaction type_Of_Interaction;
    

    public WordPool wordPool;                                   //Getting the word pools
    public Battlenode battlenode;
    [SerializeField]
    public Director gameDirector;

    public string requiredWord;                         //This is the required word that the player will have to enter correctly
    [SerializeField, HideInInspector]
    List<char> wordBreakDown;                           //Will be used to breakdown the string into a list of characters, which can be compared alongside player input.
    
    public string playerInputString;
    [SerializeField, HideInInspector]
    private List<char> playerInput;
    [SerializeField, HideInInspector]
    private int indexToCheck;

    public TextMeshProUGUI requiredWordText;
    public TextMeshProUGUI playerInputWordText;

    #region Player

    public GameObject player;
    public PlayerScript typewriterSound;

    public GameObject shotgun;
    public ShotgunScript shotgunScript;

    public GameObject typewriterHead;
    public TypewriterHeadController typewriterHeadController;

    #endregion

    [SerializeField]
    MeleeEnemyAI meleeEnemyAI;

    float waitTime = 2.0f;

    bool upperCase = PlayerPrefs.Uppercase;



    // Start is called before the first frame update
    void Start()
    {

        //Finding the Player within the Level
        player = GameObject.Find("Main Camera");
        typewriterSound = player.GetComponent<PlayerScript>();

        //Finding the shotgun
        shotgun = GameObject.Find("Shotgun");
        shotgunScript = shotgun.GetComponent<ShotgunScript>();

        //Finding typewriter head
        typewriterHead = GameObject.Find("TypewriterHead");
        typewriterHeadController = typewriterHead.GetComponent<TypewriterHeadController>();

        //Finding the Global Game Object
        wordPool = GameObject.Find("GlobalObj").GetComponent<WordPool>();

        //Finding the BattleNode
        gameDirector = GameObject.Find("GlobalObj").GetComponent<Director>();
        battlenode = gameDirector.currentBattleNode.GetComponent<Battlenode>();

        switch (type_Of_Interaction)
        {

            #region Enemies

            case Type_Of_Interaction.Zombie:
                requiredWord = wordPool.Zombie_Word_Pool[Random.Range(0, wordPool.Zombie_Word_Pool.Length)];

                meleeEnemyAI = GetComponent<MeleeEnemyAI>();

                break;
            case Type_Of_Interaction.Skeleton:
                requiredWord = wordPool.Skeleton_Word_Pool[Random.Range(0, wordPool.Skeleton_Word_Pool.Length)];

                meleeEnemyAI = GetComponent<MeleeEnemyAI>();
                break;
            case Type_Of_Interaction.Ghost:
                requiredWord = wordPool.Ghost_Word_Pool[Random.Range(0, wordPool.Ghost_Word_Pool.Length)];
                break;
            case Type_Of_Interaction.Final_Boss:
                requiredWord = wordPool.Final_Boss_Word_Pool[Random.Range(0, wordPool.Final_Boss_Word_Pool.Length)];
                break;

            #endregion

            #region Power Ups

            case Type_Of_Interaction.Health_PickUp:
                requiredWord = wordPool.Powerups_Word_Pool[0];
                break;
            case Type_Of_Interaction.Slow_Down_Time:
                requiredWord = wordPool.Powerups_Word_Pool[1];
                break;
            case Type_Of_Interaction.TwoTimes_Points:
                requiredWord = wordPool.Powerups_Word_Pool[2];
                break;

            #endregion

            #region Player Interations In Level
            
            case Type_Of_Interaction.OpenDoor:
                requiredWord = wordPool.PlayerInteraction_Word_Pool[0];
                break;
            case Type_Of_Interaction.SmashDoor:
                requiredWord = wordPool.PlayerInteraction_Word_Pool[1];
                break;
            case Type_Of_Interaction.Torch:
                requiredWord = wordPool.PlayerInteraction_Word_Pool[2];
                break;
            case Type_Of_Interaction.Continue:
                requiredWord = wordPool.PlayerInteraction_Word_Pool[3];
                break;

            #endregion

            #region Projectile

            case Type_Of_Interaction.Projectile:
                requiredWord = wordPool.Projectile_Word_Pool[Random.Range(0, wordPool.Projectile_Word_Pool.Length)];
                break;

            #endregion

        }

        requiredWordText = GameObject.Find("PlayerTextPanel").transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        playerInputWordText = GameObject.Find("PlayerTextPanel").transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        playerInputString = "";
        BreakdownRequiredWord();

    }

    void BreakdownRequiredWord()
    {
        for(int i = 0; i <= requiredWord.Length - 1; i++)
        {
            wordBreakDown.Add(requiredWord[i]);
        }
    }


    #region Player Input

    private void OnGUI()
    {

        /*
         * Keyboard Input for Player
         */


        Event e = Event.current;
        if (e.isKey)
        {
            //UPPERCASE
            if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && Input.GetKeyDown(e.keyCode))
            {
                switch (e.keyCode)
                {
                    case KeyCode.A:
                        AddToPlayerInput('A');
                        break;
                    case KeyCode.B:
                        AddToPlayerInput('B');
                        break;
                    case KeyCode.C:
                        AddToPlayerInput('C');
                        break;
                    case KeyCode.D:
                        AddToPlayerInput('D');
                        break;
                    case KeyCode.E:
                        AddToPlayerInput('E');
                        break;
                    case KeyCode.F:
                        AddToPlayerInput('F');
                        break;
                    case KeyCode.G:
                        AddToPlayerInput('G');
                        break;
                    case KeyCode.H:
                        AddToPlayerInput('H');
                        break;
                    case KeyCode.I:
                        AddToPlayerInput('I');
                        break;
                    case KeyCode.J:
                        AddToPlayerInput('J');
                        break;
                    case KeyCode.K:
                        AddToPlayerInput('K');
                        break;
                    case KeyCode.L:
                        AddToPlayerInput('L');
                        break;
                    case KeyCode.M:
                        AddToPlayerInput('M');
                        break;
                    case KeyCode.N:
                        AddToPlayerInput('N');
                        break;
                    case KeyCode.O:
                        AddToPlayerInput('O');
                        break;
                    case KeyCode.P:
                        AddToPlayerInput('P');
                        break;
                    case KeyCode.Q:
                        AddToPlayerInput('Q');
                        break;
                    case KeyCode.R:
                        AddToPlayerInput('R');
                        break;
                    case KeyCode.S:
                        AddToPlayerInput('S');
                        break;
                    case KeyCode.T:
                        AddToPlayerInput('T');
                        break;
                    case KeyCode.U:
                        AddToPlayerInput('U');
                        break;
                    case KeyCode.V:
                        AddToPlayerInput('V');
                        break;
                    case KeyCode.W:
                        AddToPlayerInput('W');
                        break;
                    case KeyCode.X:
                        AddToPlayerInput('X');
                        break;
                    case KeyCode.Y:
                        AddToPlayerInput('Y');
                        break;
                    case KeyCode.Z:
                        AddToPlayerInput('Z');
                        break;
                    case KeyCode.Alpha1:
                        AddToPlayerInput('!');
                        break;
                    case KeyCode.Space:
                        AddToPlayerInput('_');
                        break;
                    case KeyCode.Underscore:
                        AddToPlayerInput('_');
                        break;
                }              
            }
            //LOWERCASE
            else if(Input.GetKeyDown(e.keyCode))
            {
                switch (e.keyCode)
                {
                    case KeyCode.A:
                        AddToPlayerInput('a');
                        break;
                    case KeyCode.B:
                        AddToPlayerInput('b');
                        break;
                    case KeyCode.C:
                        AddToPlayerInput('c');
                        break;
                    case KeyCode.D:
                        AddToPlayerInput('d');
                        break;
                    case KeyCode.E:
                        AddToPlayerInput('e');
                        break;
                    case KeyCode.F:
                        AddToPlayerInput('f');
                        break;
                    case KeyCode.G:
                        AddToPlayerInput('g');
                        break;
                    case KeyCode.H:
                        AddToPlayerInput('h');
                        break;
                    case KeyCode.I:
                        AddToPlayerInput('i');
                        break;
                    case KeyCode.J:
                        AddToPlayerInput('j');
                        break;
                    case KeyCode.K:
                        AddToPlayerInput('k');
                        break;
                    case KeyCode.L:
                        AddToPlayerInput('l');
                        break;
                    case KeyCode.M:
                        AddToPlayerInput('m');
                        break;
                    case KeyCode.N:
                        AddToPlayerInput('n');
                        break;
                    case KeyCode.O:
                        AddToPlayerInput('o');
                        break;
                    case KeyCode.P:
                        AddToPlayerInput('p');
                        break;
                    case KeyCode.Q:
                        AddToPlayerInput('q');
                        break;
                    case KeyCode.R:
                        AddToPlayerInput('r');
                        break;
                    case KeyCode.S:
                        AddToPlayerInput('s');
                        break;
                    case KeyCode.T:
                        AddToPlayerInput('t');
                        break;
                    case KeyCode.U:
                        AddToPlayerInput('u');
                        break;
                    case KeyCode.V:
                        AddToPlayerInput('v');
                        break;
                    case KeyCode.W:
                        AddToPlayerInput('w');
                        break;
                    case KeyCode.X:
                        AddToPlayerInput('x');
                        break;
                    case KeyCode.Y:
                        AddToPlayerInput('y');
                        break;
                    case KeyCode.Z:
                        AddToPlayerInput('z');
                        break;
                    case KeyCode.Space:
                        AddToPlayerInput('_');
                        break;
                    case KeyCode.Alpha1:
                        AddToPlayerInput('1');
                        break;
                    case KeyCode.Alpha2:
                        AddToPlayerInput('2');
                        break;
                    case KeyCode.Alpha3:
                        AddToPlayerInput('3');
                        break;
                    case KeyCode.Alpha4:
                        AddToPlayerInput('4');
                        break;
                    case KeyCode.Alpha5:
                        AddToPlayerInput('5');
                        break;
                    case KeyCode.Alpha6:
                        AddToPlayerInput('6');
                        break;
                    case KeyCode.Alpha7:
                        AddToPlayerInput('7');
                        break;
                    case KeyCode.Alpha8:
                        AddToPlayerInput('8');
                        break;
                    case KeyCode.Alpha9:
                        AddToPlayerInput('9');
                        break;
                    case KeyCode.Alpha0:
                        AddToPlayerInput('0');
                        break;
                }
            }
        }
    }

    private void Update()
    {

        if (requiredWordText.text == "") SetRequiredUIText();   //If Required Word Text is empty, this will set the required text variable

        if (type_Of_Interaction == Type_Of_Interaction.Continue)
        {
            if (gameDirector.battlenodeIndex == gameDirector.Battlenodes.Count - 1)
            {

                waitTime -= Time.deltaTime;

                if (waitTime < 0)
                {
                    gameDirector.NextBattlenode();
                    typewriterSound.moving = true;
                    battlenode.ContinueInteraction.SetActive(false);
                    ClearPlayerInput();
                    ClearRequiredText();
                    this.enabled = false;
                }
            }
            else if(gameDirector.battlenodeIndex < gameDirector.Battlenodes.Count - 1)
            {
                gameDirector.NextBattlenode();
                typewriterSound.moving = true;
                battlenode.ContinueInteraction.SetActive(false);
                ClearPlayerInput();
                ClearRequiredText();
                this.enabled = false;
            }

        }
        
        
        if (playerInput.Count == wordBreakDown.Count && (type_Of_Interaction == Type_Of_Interaction.Zombie || type_Of_Interaction == Type_Of_Interaction.Skeleton))
        {
            meleeEnemyAI.Death();
            shotgunScript.ShotgunFire();
            typewriterSound.PlayerShotgunSound();
            battlenode.RemoveFromListOfInteractions(this.gameObject);

        }

        if (playerInput.Count == wordBreakDown.Count && type_Of_Interaction == Type_Of_Interaction.Health_PickUp)
        {
            typewriterSound.IncreaseHealth(20.0f);
            battlenode.RemoveFromListOfInteractions(this.gameObject);
        }
    }

    void AddToPlayerInput(char character)
    {
        typewriterSound.PlayTypeWritingKeySound();
        playerInput.Add(character);

        Debug.Log(indexToCheck);

        if (playerInput.Count != 0) indexToCheck = playerInput.Count - 1;

      

        if ((wordBreakDown.Count != 0) && (playerInput.Count != 0) && !(indexToCheck > playerInput.Count - 1) && !(indexToCheck > wordBreakDown.Count - 1))
        {
            if(playerInput[indexToCheck] != wordBreakDown[indexToCheck])
            {
                ClearPlayerInput();
            }else if(playerInput[indexToCheck] == wordBreakDown[indexToCheck])
            {
                playerInputString += character;
                playerInputWordText.SetText(playerInputString);
            }
        } 
    }



    public void ClearPlayerInput()
    {
        //Clearing Player Input, and setting Player Input string to empty

        playerInputString = "";
        playerInput.Clear();
        playerInputWordText.SetText(playerInputString);
    }

    public void OnWordCompletion()
    {
        ClearPlayerInput();             //Calling ClearPlayerInput method to clear PlayerInput string variable
        ClearRequiredText();            //Calling ClearRequiredText method to clear RequiredText string and text variable 

        if (type_Of_Interaction == Type_Of_Interaction.Zombie || type_Of_Interaction == Type_Of_Interaction.Ghost
            || type_Of_Interaction == Type_Of_Interaction.Skeleton)
        {
            Destroy(this);  //Destroy this component. This is only for enemies
        }
        else
        {
            Destroy(this.gameObject);  //Destroies Other Game objects like pickups such as: health packs
        }
    }

    #endregion

    #region Required UI Text

    public void SetRequiredUIText()
    {
        /*
         * Setting the text variable of the Required Word Text Compoent, to the Required Word.
         */

        if(requiredWordText) requiredWordText.SetText(requiredWord);
    }

    public void ClearRequiredText()
    {
        //Clearing Required Word Text Variable

        requiredWordText.SetText("");
    }

    #endregion

}
