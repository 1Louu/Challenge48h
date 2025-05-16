using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Telekinesis1 : MonoBehaviour
{
    public float raycastDistance = 3f;

    public Character character;
    public PlayerControler playerControler;
    
    public AnomalyManager anomalyManager;
    //public Animator animator;
    void Start()
    {
        
    }

    [System.Obsolete]
    void Update()
    {
        HandleInteraction();
    }

    [System.Obsolete]
    public void HandleInteraction()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("Pressed");
            RaycastHit hit;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0, 0, 0));
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, raycastDistance))
            {
                Debug.DrawRay(ray.direction, hit.point, Color.yellow);
                if (hit.collider.CompareTag("Anomaly"))
                {
                    Item var = hit.collider.gameObject.GetComponent<Item>();
                    var.PickUp(); 
                    anomalyManager.RemoveAnomaly(var);
                }

                if (hit.collider.CompareTag("normal"))
                {
                    character.LooseLife();
                }
            }
        }
    }

}