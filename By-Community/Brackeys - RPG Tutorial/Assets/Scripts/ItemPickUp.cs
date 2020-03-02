using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;

    internal override void Interact()
    {
        base.Interact();

        Debug.Log("Picking up " + item.name);
        
        
        bool wasPickedUp = Inventory.instance.Add(item);

        if(wasPickedUp)
            Destroy(gameObject);
    }
}
