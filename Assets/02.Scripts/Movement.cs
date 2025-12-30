using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed

    private Vector2 movementInput;

    private void OnEnable()
    {
        // Subscribe to the Input System's Move action
        var playerInput = GetComponent<PlayerInput>();
        playerInput.onActionTriggered += OnActionTriggered;
    }

    private void OnDisable()
    {
        // Unsubscribe from the Input System's Move action
        var playerInput = GetComponent<PlayerInput>();
        playerInput.onActionTriggered -= OnActionTriggered;
    }

    private void OnActionTriggered(InputAction.CallbackContext context)
    {
        if (context.action.name == "Move")
        {
            movementInput = context.ReadValue<Vector2>();

            // Convert 2D input to 3D movement
            Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y);

            // Move the Cube GameObject
            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}