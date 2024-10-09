using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TestInteractable : MonoBehaviour, IInteractable
{

    

    private MeshRenderer meshRenderer;
    private Outline outline;
    // Start is called before the first frame update

    private bool isActive = false;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        outline = GetComponent<Outline>();
        outline.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractionPrompt()
    {
        //outline.enabled = true;
        meshRenderer.material.color = Color.blue;
    }

    public void InteractionCancel()
    {
        //outline.enabled = false;
        if (isActive)
        {
            meshRenderer.material.color = Color.green;
        }
            

        else
        {
            meshRenderer.material.color = Color.white;
        }

    }

    public void Interact()
    {
        if (!isActive)
        {
            meshRenderer.material.color = Color.green;
            isActive = true;
        }

        else
        {
            meshRenderer.material.color = Color.white;
            isActive = false;
        }
        
        //outline.enabled = true;

        
        
    }

    
}
