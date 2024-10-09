using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHideable
{
    public void Hide(Transform pos);

    public void LeaveHide(Transform pos);

    public bool IsHiding { get; set; }
}
