using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleWeapon : GunWeapon
{
    private void OnDisable()
    {
        CancelInvoke();
    }


    public override void PressTrigger()
    {
        //base.PressTrigger();
        InvokeRepeating("ShootBullet", 0, mfTimeBetweenShoots);

    }

    public override void ReleaseTrigger()
    {
        //base.ReleaseTrigger();
        CancelInvoke("ShootBullet");
    }

}
