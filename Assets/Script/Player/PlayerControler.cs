using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    public Character character;

    [Header("Settings")]
    public bool isFirstPerson = false;
    public bool IsJumping = false;
    public bool IsInteract = false;

    [Header("References")]
    public FirstPersonCamera firstPersonCamera;
    public Telekinesis1 telekinesis;
    //public ThirdPersonCamera thirdPersonCamera;
    //public Animator animator;

    [Header("Input")]
    public Vector2 moveInputValue;
    public Vector2 lookInputValue;

    public void Start()
    {
        //SwitchCamera();
    }

    public void OnMove(InputValue value)
    {
        moveInputValue = value.Get<Vector2>();
    }

    public void OnInteract(InputValue value)
    {
        if (!IsInteract)
        {
            IsInteract = value.isPressed;
        }
    }

    public void OnJump(InputValue value)
    {
        if (!IsJumping)
        {
            IsJumping = value.isPressed;
            if (IsJumping)
            {
                //animator.SetBool(Animator.StringToHash("IsJumping"), IsJumping);
                StartCoroutine(AnimJumpDelay(0.1f));
                StartCoroutine(ResetJumpAfterDelay(0.2f));
            }
        }
    }

    [System.Obsolete]

    public void OnLook(InputValue value)
    {
        lookInputValue = value.Get<Vector2>();
    }

    //public void SwitchCamera()
    //{
    //    isFirstPerson = !isFirstPerson;
    //    ChangeCamera();
    //}
    //private void ChangeCamera()
    //{
    //    firstPersonCamera.enabled = isFirstPerson;
    //    thirdPersonCamera.enabled = !isFirstPerson;
    //
    //   if (isFirstPerson)
    //    {
    //firstPersonCamera.playerCamera.transform.parent = character.transform;
    //firstPersonCamera.playerCamera.transform.localPosition = new Vector3(0.0f, 1.5f, 0.0f);
    //}
    //else
    //{
    //thirdPersonCamera.springArm.playerCamera.transform.parent = thirdPersonCamera.springArm.transform;
    //thirdPersonCamera.springArm.playerCamera.transform.localPosition = new Vector3(0.0f, 1.5f, 2.5f);
    //}
    //}

    private void Update()
    {
        // move the character based on moveinputValue
        Vector3 x = moveInputValue.x * character.transform.right;
        Vector3 z = moveInputValue.y * character.transform.forward;

        Vector3 velocity = x + z;
        character.Move(velocity * Time.deltaTime);
        telekinesis.ButtonPress = IsInteract;
        //float AnimSpeed = velocity.magnitude;
        //AnimSpeed = Mathf.Clamp(AnimSpeed, 0.0f, 1.0f);
        //animator.SetFloat(Animator.StringToHash("Speed"), AnimSpeed);
    }

    public void OnValidate()
    {
       // SwitchCamera();
    }

    private IEnumerator ResetJumpAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        IsJumping = false;
        //animator.SetBool(Animator.StringToHash("IsJumping"), IsJumping);
    }

    private IEnumerator AnimJumpDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        character.Jump(5);
    }
}
