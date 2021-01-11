using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISizeAdjust : MonoBehaviour
{

    CanvasScaler canvasScaler;


    // Start is called before the first frame update
    void Start()
    {
        canvasScaler = GetComponent<CanvasScaler>();
    }

    // Update is called once per frame
    void Update()
    {
        canvasScaler.referenceResolution = new Vector2(Screen.width, Screen.height);
    }
}
