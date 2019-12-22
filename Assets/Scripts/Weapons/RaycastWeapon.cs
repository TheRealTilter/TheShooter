using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : Weapon {

    protected virtual void DealDamage(float damage, RaycastHit hitTarget, int typeOfDamage)
    {
        if (hitTarget.transform.tag == "TargetDummy")
        {
            hitTarget.transform.GetComponent<TargetDummyScript>().WriteDamage(damage);
        }

        if (hitTarget.transform.tag == "Enemy")
        {
            hitTarget.transform.GetComponent<EnemyHealth>().TakeDamage(damage, typeOfDamage);
        }
    }
}
