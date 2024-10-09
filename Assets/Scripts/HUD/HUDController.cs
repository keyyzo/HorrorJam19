using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] Text interactionText;

    public static HUDController instance;

    private void Awake()
    {
        instance = this;
    }

    public void EnableInteractionText()
    { 
        
        interactionText.gameObject.SetActive(true);
    }

    public void DisableInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }

}
