using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningGun : RaycastWeapon {

    public Lightning LightningRef;

    public override void Fire()
    {
        if (LightningRef.gameObject.activeSelf == false) LightningRef.gameObject.SetActive(true);
        Ray shot = new Ray(FiringPoint.transform.position, FiringPoint.transform.forward);
        RaycastHit shotHit;
        Physics.Raycast(shot, out shotHit);

        LightningRef.DrawLine(shotHit.distance, 8, 0.18f);

        CurrentAmmo -= 1;
        DealDamage(Damage, shotHit, 0);
        _firingTimer = 0.0f;
    }

    private void LateUpdate()
    {
        if (_firingTimer > _fireRate)
        {
            LightningRef.gameObject.SetActive(false);
        }
    }
}
