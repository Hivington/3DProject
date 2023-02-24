using UnityEditor;

[CustomEditor(typeof(Interactable),true)] 
public class InteractableEditor : Editor
{

    // Start is called before the first frame update
    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target;
        if(target.GetType() == typeof(EventOnlyInteractable))
        {
            interactable.promptMessage = EditorGUILayout.TextField("Prompt Message", interactable.promptMessage);
            EditorGUILayout.HelpBox("EventOnlyInteract can ONLY use UnityEvents", MessageType.Info);

            if(interactable.GetComponent<InteractionEvents>() == null)
            {

            }
        }
        else
        {
            base.OnInspectorGUI();
            if (interactable.useEvents)
            {
                if (interactable.GetComponent<InteractionEvents>() == null)
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
}
