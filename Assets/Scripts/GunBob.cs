using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBob : MonoBehaviour {


    public float Amplitude1 = 5.0f;
    public float Amplitude2 = 5.0f;
    public bool _isMoving = false;

    public float BobStart = 0;

    Vector3 StartingPosition;
    Vector3 BobPosition;

    private LissajousCurve LC;
    private Lerp _lerp;

    [SerializeField]
    private Vector3 _gunRestPoint;
    [SerializeField]
    private float _restSpeed;


    // Use this for initialization
    void Start () {
        LC = transform.GetComponent<LissajousCurve>();
        //_lerp = GetComponent<Lerp>();
        
        StartingPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        _gunRestPoint = new Vector3(0, -1, StartingPosition.z);
    }
	
	// Update is called once per frame
	void Update () {
        if (_isMoving) {
            BobPosition = LC.Calculate(StartingPosition, Amplitude1, Amplitude2, BobStart);
            transform.localPosition = BobPosition;
            BobStart += Time.deltaTime;
            //_lerp.StartLerp = false;
        }else if(!_isMoving)
        {
            BobStart = 0;
            ResetGun();
        }
    }

    public void ResetGun()
    {
        /* Trying something different
         * 
        if (!_lerp.StartLerp)
        {
            _lerp.StartTime = Time.time;
            _lerp.StartMarker = this.transform;
            _lerp.JourneyLength = Vector3.Distance(_lerp.StartMarker.position, _lerp.EndMarker.position);
        }
        
        _lerp.StartLerp = true;
        */
        float step = _restSpeed * Time.deltaTime;

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, _gunRestPoint, step);
     
    }
}
