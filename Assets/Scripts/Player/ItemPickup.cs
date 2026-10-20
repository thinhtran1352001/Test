using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField]
    private int itemId;

    [SerializeField]
    private string itemName;

    [SerializeField]
    private int quantity = 1;

    public PlayerInventory.Item CreateItem()
    {
        return new PlayerInventory.Item(
        itemId,
        itemName,
        quantity
        );
    }
}