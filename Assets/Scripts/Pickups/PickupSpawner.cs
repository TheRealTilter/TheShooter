using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour {

    public Pickup PickupToSpawn;



    private bool _isSpawned = false;
    [Header("These are private")]
    [SerializeField]
    private float _spawnTimer = 0.0f;
    [SerializeField]
    private float _spawnCooldown = 3.0f;

    //Property
    public bool IsSpawned
    {
        get { return _isSpawned; }
        set { _isSpawned = value; }
    }



    // Use this for initialization
    void Start () {
        SpawnPickup(PickupToSpawn);
	}

    private void SpawnPickup(Pickup pickup)
    {
        Pickup clone = Instantiate(pickup, transform.position, Quaternion.identity, transform);
        clone.transform.localPosition = new Vector3(0, 1.25f, 0);
        _isSpawned = true;
    }

    // Update is called once per frame
    void Update () {
        
        if (transform.childCount < 2)
        {
            _isSpawned = false;
        }

		if (!_isSpawned)
        {
            _spawnTimer += Time.deltaTime;
            if (_spawnTimer >= _spawnCooldown)
            {
                SpawnPickup(PickupToSpawn);
                _spawnTimer = 0.0f;
            }
        }
	}
}
