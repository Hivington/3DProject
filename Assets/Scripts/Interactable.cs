using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    public bool useEvents;

    //Message affiché quand le joueur regarde un interactable
    public string promptMessage;
    
    //Fonction appelé par le joueur
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
        // Un template sans code qui sera remplacé dans les sous-classes
    }
}
