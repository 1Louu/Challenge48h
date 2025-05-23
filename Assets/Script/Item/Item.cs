using UnityEngine;

public class Item : MonoBehaviour
{ 
    // public Player 
    public int DifficultyType =1;
    
    [Header("Anomaly")]
    public AnomalyAction anomalyAction;
    public bool isAnomaly;
    public bool isDuplicat=false; 
    public Material Material;
    private float hueslide=0; 
    
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
        if (isAnomaly)
        {
            this.hueslide += Time.deltaTime/10;
            if (this.hueslide >= 1)
                hueslide = 0;
            this.Material.SetFloat("_Hue", this.hueslide);
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void SetAnomaly()
    {
        this.gameObject.SetActive(true);
        this.isAnomaly = true;
        this.gameObject.tag= "Anomaly";
        anomalyAction.Execute(this);
        Debug.Log(anomalyAction + ": " + this.gameObject.name);
    }

    public void PickUp()
    {
        this.isAnomaly = false;
        this.transform.position.Set(this.definedPosition.x, this.definedPosition.y, this.definedPosition.z);
        this.transform.rotation = this.definedRotation;
        this.transform.localScale = this.definedScale;
        if(Material != null)
            GetComponent<MeshRenderer> ().material = Material;
        if (isDuplicat)
        {
            Destroy(this.gameObject);
        }
    }
}
