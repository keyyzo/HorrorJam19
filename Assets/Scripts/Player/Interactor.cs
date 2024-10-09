using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [Header("Interactor Components")]

    [SerializeField] private Transform interactorSource;
    [SerializeField] private float interactorDistance;

    IInteractable currentInteractable;
    IHideable currentHideable;
    GameObject interactable;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InteractRay();

        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();
        }

        if (currentHideable != null && Input.GetKeyDown(KeyCode.E))
        {
            if (currentHideable.IsHiding == false)
            {
                currentHideable.Hide(transform);
                currentHideable.IsHiding = true;
                Debug.Log("Hiding");
            }

            else
            { 
                currentHideable.LeaveHide(transform);
                currentHideable.IsHiding = false;
                Debug.Log("Leaving Hide");
            }
        }
    }

    void InteractRay()
    {
        Debug.DrawRay(interactorSource.position, interactorSource.forward * interactorDistance, Color.green);

        Ray ray = new Ray(interactorSource.position, interactorSource.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, interactorDistance))
        {
            

            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactableObject))
            {
                Debug.Log("An Interactable object has been detected");

                

                SetCurrentInteractable(interactableObject);



                //if (Input.GetKey(KeyCode.E))
                //{
                //    interactableObject.Interact();
                //}

            }

            else
            {
                DisableCurrentInteractable();
            }

            if (hitInfo.collider.gameObject.TryGetComponent(out IHideable hideSpot))
            {
                Debug.Log("A static hide spot is here");

                
                
                SetCurrentHideable(hideSpot);
                


            }

            else
            { 
                DisableCurrentHideable();
            }

        }

        else
        { 
            DisableCurrentInteractable();
            DisableCurrentHideable();
        }
    }

    void SetCurrentInteractable(IInteractable newInteractable)
    { 

        currentInteractable = newInteractable;
        currentInteractable.InteractionPrompt();
        HUDController.instance.EnableInteractionText();
    }

    void DisableCurrentInteractable()
    {
        HUDController.instance.DisableInteractionText();

        if (currentInteractable != null)
        { 
            currentInteractable.InteractionCancel();
            currentInteractable = null;
        }
    }

    void SetCurrentHideable(IHideable newHideable)
    {
        currentHideable = newHideable;

    }

    void DisableCurrentHideable()
    {
        if (currentHideable != null && currentHideable.IsHiding == false)
        { 
            currentHideable = null;
        }
    }

    
}
