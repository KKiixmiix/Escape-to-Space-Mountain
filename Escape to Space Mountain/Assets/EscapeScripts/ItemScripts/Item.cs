using UnityEngine;

/* Base item class: All items should derive from this class.*/

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    // Called when the item is pressed in the inventory
    public virtual void Use()
    {
        Debug.Log("Using " + name);

    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
