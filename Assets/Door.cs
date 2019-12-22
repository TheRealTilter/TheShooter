using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public Transform target;

    private BoxCollider _collider;

    private bool _open = false;
    private float speed = 2.5f;

    // Use this for initialization
    void Start () {
        _collider = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if (_open)
        {
            float step = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        }
	}


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _open = true;
        }
    }

}
