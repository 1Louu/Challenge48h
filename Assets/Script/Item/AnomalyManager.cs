using UnityEngine;

public class AnomalyManager : ItemManager
{
    private float anomalyTimer; 
    public float anomalyInterval = 15;
    public int difficulty = 1;

    public ItemManager nonAnomaly;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anomalyTimer = anomalyInterval * difficulty;
    }

    // Update is called once per frame
    void  Update()
    {
        anomalyTimer -= Time.deltaTime;
        if (anomalyTimer <= 0)
        {
            anomalyTimer = anomalyInterval * difficulty;
            AnomalyGeneration();
            Debug.Log("Anomaly insert");
        }    
    }

    public void AnomalyGeneration()
    {
        Item item = this.nonAnomaly.RandomItemPick(1);
        if (item)
        {
            item.SetAnomaly(); 
            Items.Add(item);
        }
    }
}
