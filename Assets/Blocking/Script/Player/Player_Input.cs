using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Input : MonoBehaviour
{
    // Hidden
    private Player_Behaviour playerBehaviour;

    // Event
    public void OnMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerBehaviour.MoveX = context.ReadValue<Vector2>().x;
            playerBehaviour.MoveZ = context.ReadValue<Vector2>().y;
        }

        if (context.canceled)
        {
            playerBehaviour.MoveX = 0.0f;
            playerBehaviour.MoveZ = 0.0f;
        }
    }

    public void OnMouseMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PlayerBehaviour.MouseDeltaY = context.ReadValue<Vector2>().x;
        }

        if (context.canceled)
        {
            PlayerBehaviour.MouseDeltaY = 0.0f;
        }
    }

    // Getter Setter
    public Player_Behaviour PlayerBehaviour
    {
        get => playerBehaviour;
        set => playerBehaviour = value;
    }
}
