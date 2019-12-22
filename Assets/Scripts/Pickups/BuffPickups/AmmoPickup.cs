using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : Pickup {

    public int ammoAmount = 20;

    public override void PickedUp(GameObject player)
    {
        Destroy(gameObject);
        Debug.Log("Picked up some ammo!!!");
        WeaponManager.WM.AddAmmo(ammoAmount);
        //base.PickedUp(player);
    }
}
