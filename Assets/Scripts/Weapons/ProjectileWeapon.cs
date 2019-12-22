using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon {

    public virtual void SetProjectileDamage(Projectile bullet, float damage)
    {
        bullet.Damage = damage;
    }
}