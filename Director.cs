using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Director : MonoBehaviour
{

    public List<GameObject> Battlenodes;
    public GameObject currentBattleNode;
    public int battlenodeIndex;

    public float waitTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        battlenodeIndex = 0;
        currentBattleNode = Battlenodes[battlenodeIndex];
        
        for(int i = 0; i <= Battlenodes.Count - 1; i++)
        {
            Battlenodes[i].GetComponent<Battlenode>().enabled = false;
        }

        currentBattleNode.GetComponent<Battlenode>().enabled = true;
    }

    public void NextBattlenode()
    {
        if (battlenodeIndex < Battlenodes.Count - 1)
        {
            battlenodeIndex++;
            Debug.Log(battlenodeIndex);
        }else if(battlenodeIndex == Battlenodes.Count - 1)
        {
            Debug.Log("At the end");
            SceneManager.LoadScene(3);

        }

        currentBattleNode = Battlenodes[battlenodeIndex];
    }






}
