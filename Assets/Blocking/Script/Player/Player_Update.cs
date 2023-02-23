using UnityEngine;

public class Player_Update : MonoBehaviour
{
    // Inspector
    [Header("Component")]
    [SerializeField] private Player_Behaviour playerBehaviour;
    [SerializeField] private Player_Input playerInput;

    // Update
    private void Start()
    {
        playerInput.PlayerBehaviour = playerBehaviour;
    }

    private void Update()
    {
        playerBehaviour.Rotation();
        playerBehaviour.Movement();
    }
}
