using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStaticHide : MonoBehaviour, IHideable
{
    bool IHideable.IsHiding { get; set; }

    public abstract void Hide(Transform pos);
    public abstract void LeaveHide(Transform pos);
   
   
    
}
