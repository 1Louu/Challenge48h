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

    public void RandomAnomalyInsert(int pickedDiff)
    {
        List<Item> newItem = null; 
        foreach(Item item in Items)
            if(item.DifficultyType == pickedDiff)
                newItem.Add(item);
        int choice = Random.Range(0, newItem.Count - 1);
        newItem[choice].isAnomaly = true;
        Items.Remove(newItem[choice]);
    }
}
