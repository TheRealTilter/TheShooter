using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Transform FiringPoint;
    public float Power = 10;

    private GameObject _bulletBox;
    private float _fireRate = 0.2f;
    private float _firingTimer = 1f;

    private void Awake()
    {
        _bulletBox = new GameObject("BulletBox");
    }

    private void Update()
    {
        _firingTimer += Time.deltaTime;
        if(Input.GetButton("Fire1") && (_firingTimer > _fireRate))
        {
            GameObject projectileClone = Instantiate(ProjectilePrefab, FiringPoint.position, Quaternion.identity, _bulletBox.transform);
            Rigidbody projectileRigidbody = projectileClone.GetComponent<Rigidbody> ();
            projectileRigidbody.AddForce(FiringPoint.forward * Power, ForceMode.VelocityChange);
            _firingTimer = 0.0f;
        }
    }
}
