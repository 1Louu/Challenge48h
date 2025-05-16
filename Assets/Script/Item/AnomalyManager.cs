using UnityEngine;

public class AnomalyManager : ItemManager
{
    private float anomalyTimer; 
    public float anomalyInterval;

    public ItemManager nonAnomaly;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anomalyTimer = anomalyInterval;
    }

    // Update is called once per frame
    void  Update()
    {
        anomalyTimer -= Time.deltaTime;
        if (anomalyTimer <= 0)
        {
            anomalyTimer = anomalyInterval;
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
