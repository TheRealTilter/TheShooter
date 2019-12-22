using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRaycastWeapon : RaycastWeapon {

    public Camera PlayerCamera;



    public override void Fire()
    {
        Ray shot = new Ray(FiringPoint.transform.position, FiringPoint.transform.forward);
        RaycastHit shotHit;
        Physics.Raycast(shot, out shotHit);
        Debug.Log("I just hit tag: " + shotHit.transform.tag);
        _firingTimer = 0.0f;
        CurrentAmmo -= 1;

        DealDamage(Damage,shotHit);
    }

    private void DealDamage(float damage, RaycastHit hitTarget)
    {
        if(hitTarget.transform.tag == "TargetDummy")
        {
            hitTarget.transform.GetComponent<TargetDummyScript>().WriteDamage(damage);
        }
    }
}
