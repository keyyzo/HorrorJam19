using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestStaticHide : BaseStaticHide
{
    
    [Header("Hide Position Components")]

    [SerializeField] private Transform hiddenPosition;
    [SerializeField] private Transform exitPosition;
   

    // private variables

    private bool isHiding;

    public bool IsHiding => isHiding;


    private void Start()
    {
        isHiding = false;
    }

    private void Update()
    {
       
    }

    public override void Hide(Transform pos)
    {

        // old code, player position would not update when a new prefab was placed within the scene
        // so changed by function taking in a position instead, keeps it modular

        //playerObject.SetActive(false);
        //playerObject.transform.position = new Vector3(hiddenPosition.position.x, hiddenPosition.position.y,hiddenPosition.position.z);
        //playerObject.transform.rotation = hiddenPosition.rotation;
        //playerObject.SetActive(true);

        // Disable the object temporarily, so position can be changed

        pos.gameObject.SetActive(false);

        pos.position = new Vector3(hiddenPosition.position.x, hiddenPosition.position.y, hiddenPosition.position.z);
        pos.rotation = hiddenPosition.rotation;

        pos.gameObject.SetActive(true);
    }

    public override void LeaveHide(Transform pos)
    {
        //playerObject.SetActive(false);
        //playerObject.transform.position = new Vector3(exitPosition.position.x, exitPosition.position.y, exitPosition.position.z);
        //playerObject.transform.rotation = exitPosition.rotation;
        //playerObject.SetActive(true);

        // Disable the object temporarily, so position can be changed

        pos.gameObject.SetActive(false);

        pos.position = new Vector3(exitPosition.position.x, exitPosition.position.y, exitPosition.position.z);
        pos.rotation = exitPosition.rotation;

        pos.gameObject.SetActive(true);
    }

    

    

    
}
