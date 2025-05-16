using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<Item> Items;
    private float anomalyTimer; 
    public float anomalyInterval;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anomalyTimer = anomalyInterval;
    }

    // Update is called once per frame
    void Update()
    {
        anomalyTimer -= Time.deltaTime;
        if (anomalyTimer <= 0)
        {
            anomalyTimer = anomalyInterval;
            RandomAnomalyInsert(1);
            Debug.Log("Anomaly insert");
        }
    }

    public void RandomAnomalyInsert(int pickedDiff)
    {
        List<Item> newItem = new List<Item>(); 
        foreach(Item item in Items)
            if (item.DifficultyType == pickedDiff)
            {
                newItem.Add(item);
            }
        int choice = Random.Range(0, newItem.Count - 1);
        newItem[choice].isAnomaly = true;
        newItem[choice].SetAnomaly(); 
        Items.Remove(newItem[choice]);
    }
}
