using UnityEngine;

public class Player_Behaviour : MonoBehaviour
{
    // Inspector
    [Header("Component")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private CharacterController playerController;

    [Header("Tweak")]
    [SerializeField] private float movementSpeed = 0.0f;
    [SerializeField] private float rotationSpeed = 0.0f;

    // Hidden
    private float moveX = 0.0f;
    private float moveZ = 0.0f;
    private float mouseDeltaY = 0.0f;

    // Method
    public void Movement()
    {
        Vector3 move = new Vector3(moveX, 0.0f, moveZ);
        playerController.Move(playerTransform.TransformDirection(movementSpeed * Time.deltaTime * move));
    }

    public void Rotation()
    {
        playerTransform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * mouseDeltaY, Space.Self);
    }

    // Getter Setter
    public float MoveX
    {
        get => moveX;
        set => moveX = value;
    }
    public float MoveZ
    {
        get => moveZ;
        set => moveZ = value;
    }
    public float MouseDeltaY
    {
        get => mouseDeltaY;
        set => mouseDeltaY = value;
    }
}
