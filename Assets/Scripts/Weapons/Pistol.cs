using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : RaycastWeapon {

    public override void Fire()
    {
        Ray shot = new Ray(FiringPoint.transform.position, FiringPoint.transform.forward);
        RaycastHit shotHit;
        Physics.Raycast(shot, out shotHit);
        _firingTimer = 0.0f;
        CurrentAmmo -= 1;
        _anim.Play("PistolMuzzleFlash");
        DealDamage(Damage, shotHit, 0);
    }

    /*protected override void DealDamage(float damage, RaycastHit hitTarget)
    {
        if (hitTarget.transform.tag == "TargetDummy")
        {
            hitTarget.transform.GetComponent<TargetDummyScript>().WriteDamage(damage);
        }
    }*/
}
