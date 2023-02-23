using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    // Comme il va y avoir qu'un seul InputManager, on le met static pour qu'il soit accessible de partout. C'est une sorte de Singleton.
    private static InputManager instance;

    public static InputManager Instance 
    { 
        get 
        { 
            return instance; 
        } 
    }

    private PlayerControls playerControls;


    //Assigne en premier un PlayerControls avec les valeurs que l'on a mis dans le Input Manager
    private void Awake()
    {
        //Pour pas causer de bug, si jamais il y a une autre instance ou que l'instance != null, on détruis tout
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        playerControls = new PlayerControls();
        Cursor.visible = false;
    }

    //Quand l'objet(joueur en l'occurence) est enable, le playerControls est enable. Il est disable quand inversement
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    //Méthode pour chopper les WASD du joueur en Vector2, en les reprenants de playerControls
    public Vector2 GetPlayerMovement()
    {
        return playerControls.Player.Movement.ReadValue<Vector2>();
    }
    //Méthode pour chopper les mouvements de souris du joueur en Vector2, en les reprenants de playerControls
    public Vector2 GetMouseDelta()
    {
        return playerControls.Player.Look.ReadValue<Vector2>();
    }
    //Méthode pour savoir si le joueur a jump
    public bool PlayerJumpedThisFrame()
    {
        return playerControls.Player.Jump.triggered;
    }
    public bool PlayerRun()
    {
        return playerControls.Player.Run.inProgress;
    }
}
