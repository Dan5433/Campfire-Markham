using Input;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    static PlayerInput playerInput;

    [SerializeField] HingeJoint2D leftArm, rightArm, leftLeg, rightLeg;
    [SerializeField] float maxDegreesPerSecond, maxSpeedChange, speedFalloff, sprintMultiplier;

    private void Awake()
    {
        playerInput = new();

        playerInput.Enable();
    }

    private void Update()
    {
        Vector2 movementInput = playerInput.Player.Move.ReadValue<Vector2>();
        Debug.Log(movementInput);

        float currentArmSpeed = (leftArm.motor.motorSpeed + rightArm.motor.motorSpeed) / 2;

        JointMotor2D leftArmMotor = leftArm.motor;
        JointMotor2D rightArmMotor = rightArm.motor;

        float newArmSpeed = Mathf.MoveTowards(currentArmSpeed, maxDegreesPerSecond * movementInput.y,
            movementInput.y != 0 ? maxSpeedChange : speedFalloff);

        leftArmMotor.motorSpeed = newArmSpeed;
        leftArmMotor.maxMotorTorque = movementInput.y == 0 ? 0 : maxDegreesPerSecond;
        rightArmMotor.motorSpeed = newArmSpeed;
        rightArmMotor.maxMotorTorque = movementInput.y == 0 ? 0 : maxDegreesPerSecond;

        leftArm.motor = leftArmMotor;
        rightArm.motor = rightArmMotor;



        float currentLegSpeed = (leftLeg.motor.motorSpeed + rightLeg.motor.motorSpeed) / 2;

        JointMotor2D leftLegMotor = leftLeg.motor;
        JointMotor2D rightLegMotor = rightLeg.motor;

        float newLegSpeed = Mathf.MoveTowards(currentLegSpeed, maxDegreesPerSecond * movementInput.x,
            movementInput.x != 0 ? maxSpeedChange : speedFalloff);

        leftLegMotor.motorSpeed = newLegSpeed;
        leftLegMotor.maxMotorTorque = movementInput.x == 0 ? 0 : maxDegreesPerSecond;
        rightLegMotor.motorSpeed = newLegSpeed;
        rightLegMotor.maxMotorTorque = movementInput.x == 0 ? 0 : maxDegreesPerSecond;

        leftLeg.motor = leftLegMotor;
        rightLeg.motor = rightLegMotor;
    }

    private void OnDestroy()
    {
        playerInput.Disable();
    }
}
