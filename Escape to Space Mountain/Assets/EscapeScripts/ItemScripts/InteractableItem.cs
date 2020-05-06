using UnityEngine;
using UnityEditor;
using UnityEngine.VFX;

public class InteractableItem : Interactable
{
    public override void Interact()
    {
        Debug.Log("Interacting with item " + transform.name);

        FindObjectOfType<ItemPickup>().PickUp();
    }
}