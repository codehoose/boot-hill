using UnityEngine;
using UnityEngine.InputSystem;

public class ManualPlayerController : MonoBehaviour
{
    public InputAction movement;

    public InputAction fire;

    public PlayerLocomotionController locomotion;

    private void OnEnable()
    {
        movement.Enable();
        fire.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        fire.Disable();
    }

    void Update()
    {
        locomotion.UpdateMovement(movement.ReadValue<Vector2>());

        if (fire.ReadValue<float>() > 0)
        {
            locomotion.Fire();
        }
    }
}
