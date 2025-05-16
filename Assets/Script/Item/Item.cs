using UnityEngine;

public class Item : MonoBehaviour
{ 
    // public Player player
    public string itemName;
    public string itemType;
    public int DifficultyType;
    public bool isAnomaly; 
    
    public AnomalyAction anomalyAction;
    
    [Header("Definied Basis")]
    public Vector3 definedPosition;
    public Vector3 definedRotation;
    public Vector3 definedScale;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.definedPosition = this.transform.position;
        this.definedRotation = this.transform.eulerAngles; 
        this.definedScale = this.transform.localScale;
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

    public void SetAnomaly()
    {
        this.isAnomaly = true;
        anomalyAction.Execute(this);
    }
}
