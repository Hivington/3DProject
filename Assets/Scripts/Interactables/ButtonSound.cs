using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : Interactable
{

    private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Play sound
    protected override void Interact()
    {
        sound.Play();
    }
}
