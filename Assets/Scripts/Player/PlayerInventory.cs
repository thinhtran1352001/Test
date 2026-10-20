using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private CoinCounterUI coinCounterUI;

    [SerializeField]
    private InventoryUI inventoryUI;

    private int coinCount;

    private void RefreshUI()
    {
        if (inventoryUI != null)
        {
            inventoryUI.Refresh(items);
        }
    }
    private List<Item> items = new List<Item>();

    public IReadOnlyList<Item> Items
    {
        get { return items; }
    }

    public int CoinCount
    {
        get
        {
            return coinCount;
        }
    }
    private void Start()
    {
        if (coinCounterUI != null)
        {
            coinCounterUI.SetCoinCount(coinCount);
        }
    }
    public void AddCoin(int amount)
    {
        if (amount <= 0)
        {
            return;
        }

        coinCount += amount;

        if (coinCounterUI != null)
        {
            coinCounterUI.SetCoinCount(coinCount);
        }
    }
    public void AddItem(Item newItem)
    {
        Item existingItem = FindItem(newItem.Id);

        if (existingItem != null)
        {
            existingItem.Quantity += newItem.Quantity;
            // return;
        }
        else
        {
            items.Add(newItem);
        }

        RefreshUI();
    }
    public Item FindItem(int id)
    {
        return items.Find(item => item.Id == id);
    }
    public void UseHealthPotion(PlayerHealth playerHealth)
    {
        const int healthPotionId = 1;
        bool removed = RemoveItem(healthPotionId, 1);
        if (!removed) return;

        playerHealth.Heal(25);
    }
    public bool RemoveItem(int id, int amount)
    {
        if (amount <= 0) return false;

        Item item = FindItem(id);
        if (item == null) return false;
        if (item.Quantity < amount) return false;

        item.Quantity -= amount;
        if (item.Quantity == 0)
        {
            items.Remove(item);
        }

        RefreshUI();
        return true;
    }
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }

        // Sửa lại dùng đúng tên Property viết hoa
        public Item(int id, string itemName, int quantity)
        {
            Id = id;
            ItemName = itemName;
            Quantity = quantity;
        }
    }
}