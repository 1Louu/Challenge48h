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
    public Material anomalyMaterial;
    
    [Header("Definied Basis")]
    public Vector3 definedPosition;
    public Quaternion definedRotation;
    public Vector3 definedScale;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.transform.position.Set(this.definedPosition.x, this.definedPosition.y, this.definedPosition.z);
        this.transform.rotation = this.definedRotation;
        this.transform.localScale = this.definedScale;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        this.gameObject.tag= "Anomaly";
        anomalyAction.Execute(this);
    }

    public void ChangeText(float newValue)
    {
        this.anomalyMaterial.SetFloat("_TextureBlending", newValue);
    }
}
