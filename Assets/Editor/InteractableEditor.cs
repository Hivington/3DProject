using UnityEditor;
public class InteractableEditor : Editor
{

    [CustomEditor(typeof(Interactable),true)]
    // Start is called before the first frame update
    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target;
        base.OnInspectorGUI();
        if (interactable.useEvents)
        {
            if(interactable.GetComponent<InteractionEvents>() == null) 
            {
                interactable.gameObject.AddComponent<InteractionEvents>();
            }
            
        }
        else
        {
            if (interactable.GetComponent<InteractionEvents>() != null)
            {
                DestroyImmediate(interactable.GetComponent<InteractionEvents>());
            }
        }
    }
}
