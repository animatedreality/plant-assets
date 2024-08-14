using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//require audiosource
[RequireComponent(typeof(AudioSource))]
public class TogglePlay_NS : MonoBehaviour
{
    //TOGGLING PLAY/PAUSE BY CLICKING ON THE GAMEOBJECT
    public AudioSource[] audioSources;
    public UnityEvent onClicked;
    public bool volumeOn = false;

    //create a unity event that is called when toggleplay is called
    void Start()
    {
        if (onClicked == null)
            onClicked = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {
        //if left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                onClicked.Invoke();
                ToggleVolume();
            }
        }
    }

    void ToggleVolume(){
        volumeOn = !volumeOn;
        GetComponent<AudioSource>().volume = volumeOn ? 1f : 0f;

        //toggle volume for the audioSources array
        foreach (AudioSource source in audioSources)
        {
            source.volume = volumeOn ? 1f : 0f;
        }
    }
}
