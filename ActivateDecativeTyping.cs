using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateDecativeTyping : MonoBehaviour
{
    TypingMechanic typingMechanic;
    public bool currentlySelected;
    
    private void Start()
    {
        typingMechanic = GetComponent<TypingMechanic>();
        //Deactivate();
    }

    private void Update()
    {
        if (currentlySelected == true && typingMechanic) typingMechanic.enabled = true;
        else if (currentlySelected == false && typingMechanic) typingMechanic.enabled = false;
    }
    public void Activate()
    {
        typingMechanic = GetComponent<TypingMechanic>();

        currentlySelected = true;
        typingMechanic.SetRequiredUIText();
        
    }

    public void Deactivate()
    {

        Debug.Log("Deactivate Called");

        if (typingMechanic)
        {
            currentlySelected = false;
        }
    }
}
