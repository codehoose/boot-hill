using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ManualPlayerController : MonoBehaviour
{
    public InputAction movement;

    public InputAction fire;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var delta = movement.ReadValue<Vector2>() * 400 * Time.deltaTime;
        transform.position += new Vector3(delta.x, delta.y, transform.position.z);

        if (fire.ReadValue<float>() > 0)
        {
            Debug.Log("FIRE");
        }
    }
}
