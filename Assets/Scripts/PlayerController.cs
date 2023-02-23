using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private InputManager inputManager;
    private Transform cameraTransform;

    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float runMultp = 2f;

    //On choppe le CharacterController
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        //On affecte constamment groundedPlayer en true ou false grace à isGrounded
        groundedPlayer = controller.isGrounded;

        //Si le joueur est au sol et qu'il a une vélocité plus petite que 0, on reset sa vélocité à 0
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        //On reprend les inputs venant de l'input Manager pour le WASD, et on assigne à un vector2 tout ça
        Vector2 movement = inputManager.GetPlayerMovement();

        //On applique ce Vector2 dans un Vector3 (avec y à zéro car c'est le saut).
        Vector3 move = new Vector3(movement.x, 0f, movement.y);

        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;
        //Grâce à Move(), on bouge le joueur selon le vector3 précédent qu'on multiplie par Time.deltaTime et la playerSpeed
        if (inputManager.PlayerRun() ==true)
        {
            Debug.Log("Run");
            controller.Move(move * Time.deltaTime * playerSpeed * runMultp);
        }
        else
        {
            controller.Move(move * Time.deltaTime * playerSpeed);
        }

        //Si move est différent que (0, 0 ,0), on applique le Vector3 au gameObject.transform.forward
        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}

        // Le saut en choppant la touche de l'inputManager
        if (inputManager.PlayerJumpedThisFrame() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        //On applique la gravité à la vélocité 
        playerVelocity.y += gravityValue * Time.deltaTime;

        //On applique la vélocité au joueur
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
