using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkipIntro : MonoBehaviour
{

    float waitTime = 3.0f;
    Slider slider;

    private void Start()
    {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            waitTime -= Time.deltaTime;
            slider.value += Time.deltaTime;

            if (waitTime < 0)
            {
                SceneManager.LoadScene(1);
                
            }

        }else if (Input.GetKeyUp(KeyCode.Space))
        {
            waitTime = 3.0f;
            slider.value = 0.0f;
        }

    }
}
