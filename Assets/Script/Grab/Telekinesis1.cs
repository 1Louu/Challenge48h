using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Telekinesis1 : MonoBehaviour
{
    public Transform holdPosition;
    public float grabSpeed = 10f;
    public float throwForce = 10f;
    public float raycastDistance = 3f;

    private Rigidbody grabbedObject;
    public bool ButtonPress = false;
    private bool isGrabbing = false;
    public bool isThrowing = false;
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
        if (ButtonPress)
        {
            {
                {
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

                    if (isGrabbing && grabbedObject != null)
                    {
                        MoveObjectToHoldPosition();
                    }

                    if (ButtonPress && isGrabbing)
                    {
                        //animator.SetBool("IsThrowing", true);
                        StartCoroutine(AnimThrowDelay(0.8f));
                        StartCoroutine(ResetThrowingAfterDelay(1.5f));
                    }
                }
            }
        }
    }


    [System.Obsolete]
    public void TryGrabObject(GameObject objectToGrab)
    {
        Rigidbody rb = objectToGrab.GetComponent<Rigidbody>();
        if (rb != null)
        {
            grabbedObject = rb;
            grabbedObject.useGravity = false;
            grabbedObject.drag = 10;
            grabbedObject.constraints = RigidbodyConstraints.FreezeRotation;
            grabbedObject.isKinematic = true;
            isGrabbing = true;
        }
    }
    public void MoveObjectToHoldPosition()
    {
        grabbedObject.transform.position = Vector3.Lerp(grabbedObject.transform.position, holdPosition.position, grabSpeed * Time.deltaTime);
    }

    [System.Obsolete]
    public void ThrowObject()
    {
        isGrabbing = false;
        grabbedObject.useGravity = true;
        grabbedObject.drag = 1;
        grabbedObject.constraints = RigidbodyConstraints.None;
        grabbedObject.isKinematic = false;
        Vector3 throwDirection = character.transform.forward; 
        grabbedObject.velocity = throwDirection * throwForce; 
        grabbedObject = null; 
    }

    private IEnumerator ResetThrowingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isThrowing = false;
        playerControler.IsInteract = false;
        ButtonPress = false;
        //animator.SetBool(Animator.StringToHash("IsThrowing"), isThrowing);
    }

    [System.Obsolete]
    private IEnumerator AnimThrowDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ThrowObject();
    }
}