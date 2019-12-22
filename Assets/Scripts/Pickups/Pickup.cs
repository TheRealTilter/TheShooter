using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    private PickupSpawner _pickupSpawner;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PickedUp(other.gameObject);
        }
    }
    
    public virtual void PickedUp(GameObject player)
    {
        
        Destroy(this.gameObject);
        Debug.Log("ERROR: Lowest level pickup");
    }

    private void Start()
    {
        //Obsolite, PickupSpawner takes care of the code here
        //_pickupSpawner = transform.parent.gameObject.GetComponent<PickupSpawner>();
    }
}
