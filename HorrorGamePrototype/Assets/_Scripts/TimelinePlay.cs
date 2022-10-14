using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class TimelinePlay : MonoBehaviour
{
    public PlayableDirector director; 
    public GameObject controlPanel; 
    private void Awake() 

    {   director = GetComponent<PlayableDirector>(); 
        director.played += Director_Played; 
        director.stopped += Director_Stopped; 
    }
    private void Director_Stopped(PlayableDirector obj) 
    {
        PortalDoorTrigger.PlayTime = true;
    }
    private void Director_Played(PlayableDirector obj) 
    {
        PortalDoorTrigger.PlayTime = false;
    }
    public void StartTimeline() 
    { 
        director.Play();
    }
}
