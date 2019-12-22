using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour {

    public Transform StartMarker;
    public Transform EndMarker;
   

    public float JourneyLength;

    public float Speed = 2;

    public float StartTime;

    public bool StartLerp = false;

    void Start()
    {
        // Keep a note of the time the movement started.
        StartTime = Time.time;
        
    }


    // Update is called once per frame
    void Update () {
        if (StartLerp)
        {
            float distCovered = (Time.time - StartTime) * Speed;

            float fracJourney = distCovered / JourneyLength;

            transform.position = Vector3.Lerp(StartMarker.position, EndMarker.position, fracJourney);
        }
    }
}
