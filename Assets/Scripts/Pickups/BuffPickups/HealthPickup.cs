using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup {

    public float HealAmount = 20.0f;

    public override void PickedUp(GameObject player)
    {
        HealthManager playerHPManager = player.GetComponent<HealthManager>();
        playerHPManager.HealFor(HealAmount);
        Destroy(this.gameObject);
        //base.PickedUp(player);
    }

    
}
