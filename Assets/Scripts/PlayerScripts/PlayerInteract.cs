using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    private Camera cam;
    //Position du raycast par rapport à la caméra
    Vector3 pos = new Vector3(0.5f, 0.5f, 0);

    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        //On choppe tout les components
        cam = GetComponent<Camera>(); 
        playerUI = GetComponent<PlayerUI>();
        inputManager = InputManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        //Empty text when  no trigger
        playerUI.UpdateText(string.Empty);

        //Création du raycast, setup au centre de l'écran
        Ray ray = cam.ViewportPointToRay(pos);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.yellow);
        RaycastHit hitInfo; 

        //Le raycast détecte si il y a un objet avec le bon masque dans son rayon, retourne true si oui
        if(Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            //On check si jamais la valeur n'est pas null
            if (hitInfo.collider.GetComponent<Interactable>() != null) 
            {
                //On crée une variable interactable égale au script interactable sur l'objet que le raycast collide
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                //On affiche le prompt de cet objet
                playerUI.UpdateText(interactable.promptMessage);

                //Si le joueur appuie sur E, trigger la méthode Interact de l'objet
                if (inputManager.PlayerInteract())
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
