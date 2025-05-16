using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<Item> Items;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Item RandomItemPick(int pickedDiff)
    {
        List<Item> newItem = new List<Item>(); 
        foreach(Item item in Items)
            if (item.DifficultyType == pickedDiff)
            {
                newItem.Add(item);
            }

        if (newItem.Count == 0)
            return null;
        int choice = Random.Range(0, newItem.Count - 1);
        Items.Remove(newItem[choice]);
        return  newItem[choice];
    }
}
