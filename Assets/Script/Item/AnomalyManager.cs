using TMPro;
using UnityEngine;

public class AnomalyManager : ItemManager
{
    private float anomalyTimer; 
    public float anomalyInterval = 15;
    public int difficulty = 1;
    public Character character; 
    public ItemManager nonAnomaly;

    public TextMeshProUGUI timerText; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anomalyTimer = anomalyInterval * difficulty;
    }

    // Update is called once per frame
    void  Update()
    {
        anomalyTimer -= Time.deltaTime;
        timerText.text = anomalyTimer.ToString();
        if (anomalyTimer <= 0)
        {
            anomalyTimer = anomalyInterval * difficulty;
            AnomalyGeneration();
            Debug.Log("Anomaly insert");
            if (Items.Count > 0)
            {
                character.LooseLife();
            }
        }
    }

    public void AnomalyGeneration()
    {
        Item item = this.nonAnomaly.RandomItemPick();
        if (item)
        {
            item.SetAnomaly(); 
            Items.Add(item);
        }
    }

    public void RemoveAnomaly(Item item)
    {
        Items.Remove(item);
    }
}
