using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float Damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "TargetDummy")
        {
            other.GetComponent<TargetDummyScript>().WriteDamage(Damage);
            Destroy(gameObject);

        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
