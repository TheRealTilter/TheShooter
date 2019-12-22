using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : ProjectileWeapon {

	// Use this for initialization
	void Start () {
		
	}

    public override void Fire()
    {
        GameObject projectileClone = Instantiate(ProjectilePrefab, FiringPoint.position, Quaternion.identity, _bulletBox.transform);
        Rigidbody projectileRigidbody = projectileClone.GetComponent<Rigidbody>();
        SetProjectileDamage(projectileClone.GetComponent<Projectile>(), Damage);
        projectileRigidbody.AddForce(FiringPoint.forward * Power, ForceMode.VelocityChange);
        _firingTimer = 0.0f;
        CurrentAmmo -= 1;
    }
}
