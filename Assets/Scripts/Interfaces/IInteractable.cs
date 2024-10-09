using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void InteractionPrompt();
    public void InteractionCancel();
    public void Interact();

    public GameObject gameObject { get; }
}
