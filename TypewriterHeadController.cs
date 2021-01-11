using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypewriterHeadController : MonoBehaviour
{

    Image typewriterImage;
    RectTransform typewriterPos;

    float startingY;
    float newY;
    float addBy;
    float waitTime;

    bool showing;

    // Start is called before the first frame update
    void Start()
    {
        typewriterImage = GetComponent<Image>();
        typewriterPos = GetComponent<RectTransform>();

        addBy = 37.0f;

        startingY = typewriterPos.anchoredPosition.y;
        newY = startingY;

        typewriterImage.enabled = false;

        waitTime = 0.2f;
    }

    private void Update()
    {

     

    }


    public void HeadAppear(bool appear)
    {
        typewriterImage.enabled = appear;
        
        if(appear == false) UpdatePos();
        

      

    }


    void UpdatePos()
    {
        newY -= addBy;

        typewriterPos.anchoredPosition = new Vector3(typewriterPos.anchoredPosition.x, newY);

        Debug.Log(newY);
    }

    public void ResetHeadPos()
    {
        newY = startingY;
        typewriterPos.anchoredPosition = new Vector3(typewriterPos.anchoredPosition.x, newY);
    }




}
