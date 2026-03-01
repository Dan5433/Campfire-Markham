using Input;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    static PlayerInput playerInput;

    [SerializeField] HingeJoint2D leftArm, rightArm, leftLeg, rightLeg;
    [SerializeField] float maxDegreesPerSecond, maxSpeedChange, sprintMultiplier;

    private void Awake()
    {
        playerInput = new();

        playerInput.Enable();
    }

    private void Update()
    {
        Vector2 movementInput = playerInput.Player.Move.ReadValue<Vector2>();

        float currentArmSpeed = (leftArm.motor.motorSpeed + rightArm.motor.motorSpeed) / 2;
        float currentLegSpeed = (leftLeg.motor.motorSpeed + rightLeg.motor.motorSpeed) / 2;
    }
}
