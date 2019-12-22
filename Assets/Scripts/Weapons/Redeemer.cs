using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redeemer : ProjectileWeapon {

    public static Redeemer StaticRedeem;

    public Camera GunCamera, MainCamera;
    public Camera MissileCamera;

    public Transform PlayerY, PlayerCameraX;

    public bool RedeemerAlt = false;

    private void Awake()
    {
        StaticRedeem = this;
    }


    public override void Fire()
    {
        GameObject projectileClone = Instantiate(ProjectilePrefab, FiringPoint.position, FiringPoint.rotation);
        Rigidbody projectileRigidbody = projectileClone.GetComponent<Rigidbody>();
        SetProjectileDamage(projectileClone.GetComponent<Projectile>(), Damage);
        _firingTimer = 0.0f;
        CurrentAmmo -= 1;
    }

    public override void AltFire()
    {
        GameObject projectileClone = Instantiate(ProjectilePrefab, FiringPoint.position, FiringPoint.rotation);
        Rigidbody projectileRigidbody = projectileClone.GetComponent<Rigidbody>();
        SetProjectileDamage(projectileClone.GetComponent<Projectile>(), Damage);
        MissileCamera = projectileClone.GetComponentInChildren<Camera>();

        ReverseCameras();

        RedeemerAlt = true;

        _firingTimer = 0.0f;
        CurrentAmmo -= 1;
    }


    public void ReverseCameras()
    {
        if (MainCamera.enabled == true)
        {
            MainCamera.enabled = false;
            GunCamera.enabled = false;
            MissileCamera.enabled = true;
        }
        else
        {
            MainCamera.enabled = true;
            GunCamera.enabled = true;
            MissileCamera.enabled = false;
        }
    }
}
