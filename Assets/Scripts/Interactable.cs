using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    public bool useEvents;

    //Message affich� quand le joueur regarde un interactable
    public string promptMessage;
    
    //Fonction appel� par le joueur
    public void BaseInteract()
    {
        if (useEvents)
        {
            GetComponent<InteractionEvents>().OnInteract.Invoke(); 
            Interact();
        }
        
    }

    protected virtual void Interact()
    {
        // Un template sans code qui sera remplac� dans les sous-classes
    }
}
