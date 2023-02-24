using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerUI : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI prompText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Change le texte d'un TMPRO
    public void UpdateText(string promptMessage)
    {
        prompText.text = promptMessage;
    }
}
