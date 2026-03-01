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
        playerInput.Player.LeftArm.performed += UseLeftArm;

        playerInput.Enable();
    }

    private void UseLeftArm(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Left Arm");
    }

    private void Crouch(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Crouch");
    }
    private void Uncrouch(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Uncrouch");
    }

}
