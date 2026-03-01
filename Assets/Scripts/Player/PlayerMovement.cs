using Input;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    static PlayerInput playerInput;

    [SerializeField] HingeJoint2D leftArm, rightArm, leftLeg, rightLeg;
    [SerializeField] float maxDegreesPerSecond, maxSpeedChange, speedFalloff, sprintMultiplier;
    [SerializeField] Slider staminaBar;
    [SerializeField] float stamina, maxStamina, staminaDecreaseDelta, staminaRegenDelta;
    bool isSprinting = false;
    bool isExhausted = false;

    private void Awake()
    {
        stamina = maxStamina;

        playerInput = new();

        playerInput.Player.Sprint.performed += (UnityEngine.InputSystem.InputAction.CallbackContext obj) => isSprinting = true;
        playerInput.Player.Sprint.canceled += (UnityEngine.InputSystem.InputAction.CallbackContext obj) => isSprinting = false;

        playerInput.Enable();
    }

    private void Update()
    {
        Vector2 movementInput = playerInput.Player.Move.ReadValue<Vector2>();
        Debug.Log(movementInput);

        UpdateStamina();

        UpdateMotorDualLimb(movementInput.y, leftArm, rightArm);
        UpdateMotorDualLimb(movementInput.x, leftLeg, rightLeg);
    }

    void UpdateMotorDualLimb(float movement, HingeJoint2D limb1, HingeJoint2D limb2)
    {
        float currentSpeed = (limb1.motor.motorSpeed + limb2.motor.motorSpeed) / 2;

        float newSpeed = Mathf.MoveTowards(currentSpeed, GetMaxDegreesPerSecond() * movement,
            movement != 0 ? maxSpeedChange : speedFalloff);

        JointMotor2D limb1Motor = limb1.motor;
        JointMotor2D limb2Motor = limb2.motor;

        limb1Motor.motorSpeed = newSpeed;
        limb1Motor.maxMotorTorque = movement == 0 ? 0 : GetMaxDegreesPerSecond();
        limb2Motor.motorSpeed = newSpeed;
        limb2Motor.maxMotorTorque = movement == 0 ? 0 : GetMaxDegreesPerSecond();

        limb1.motor = limb1Motor;
        limb2.motor = limb2Motor;
    }

    void UpdateStamina()
    {
        if (!isSprinting)
        {
            if (stamina < maxStamina)
                stamina = Mathf.Clamp(stamina + Time.deltaTime * staminaRegenDelta, 0, maxStamina);
            else
                isExhausted = false;
        }


        if (isSprinting)
            stamina = Mathf.Clamp(stamina - Time.deltaTime * staminaDecreaseDelta, 0, maxStamina);

        if (stamina == 0 || isExhausted)
        {
            isSprinting = false;
            isExhausted = true;
        }

        staminaBar.value = stamina / maxStamina;
    }

    float GetMaxDegreesPerSecond()
    {
        return isSprinting ? maxDegreesPerSecond * sprintMultiplier : maxDegreesPerSecond;
    }

    private void OnDestroy()
    {
        playerInput.Disable();
    }
}
