using Input;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    static PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new();

        playerInput.Player.Crouch.performed += Crouch;
        playerInput.Player.Crouch.canceled += Uncrouch;

        playerInput.Player.Crawl.performed += Crawl;
        playerInput.Player.Crawl.canceled += Uncrawl;

        playerInput.Player.HoldBreath.performed += HoldBreath;
        playerInput.Player.HoldBreath.canceled += StopHoldingBreath;

        playerInput.Player.LeftArm.performed += UseLeftArm;
        playerInput.Player.RightArm.performed += UseRightArm;
        playerInput.Player.LeftLeg.performed += UseLeftLeg;
        playerInput.Player.RightLeg.performed += UseRightLeg;

        playerInput.Enable();
    }

    void UseLeftArm(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Left Arm");
    }

    void UseRightArm(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Right Arm");
    }

    void UseLeftLeg(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Left Leg");
    }

    void UseRightLeg(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Right Leg");
    }

    void Crouch(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Crouch");
    }
    void Uncrouch(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Uncrouch");
    }

    void Crawl(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Crawl");
    }
    void Uncrawl(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Uncrawl");
    }
    void HoldBreath(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Holding Breath...");
    }
    void StopHoldingBreath(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Breathing again");
    }
}
