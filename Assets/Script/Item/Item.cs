using UnityEngine;

public class Item : MonoBehaviour
{ 
    // public Player 
    public string itemName;
    public string itemType;
    public int DifficultyType;
    
    [Header("Anomaly")]
    public AnomalyAction anomalyAction;
    public bool isAnomaly;
    public float anomalySelfTest;  
    public Material anomalyMaterial;
    
    [Header("Definied Basis")]
    public Vector3 definedPosition;
    public Quaternion definedRotation;
    public Vector3 definedScale;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.transform.position = this.definedPosition;
        this.transform.rotation = this.definedRotation;
        this.transform.localScale = this.definedScale;
    }

    // Update is called once per frame
    void Update()
    {
        this.anomalySelfTest -= Time.deltaTime;

        if (this.anomalySelfTest <= 0 && !this.isAnomaly)
        {
            SetAnomaly();
        }
    }

    public void PickUp()
    {
        if (this.isAnomaly)
        {
            
        }
        // Player.LooseSanity()
        // Play animationPickup here
        
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void SetAnomaly()
    {
        this.isAnomaly = true;
        anomalyAction.Execute(this);
    }

    public void ChangeText(float newValue)
    {
        Debug.Log("SetAnomaly");
        this.anomalyMaterial.SetFloat("_TextureBlending", newValue);
    }
}
