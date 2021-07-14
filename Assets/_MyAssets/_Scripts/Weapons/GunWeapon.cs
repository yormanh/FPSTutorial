using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : BaseWeapon
{
    [SerializeField] GameObject mBulletPrefab;
    [SerializeField] Transform mShootPoint;

    [SerializeField] float mfShootForce = 50f;

    float mfNextShootTime = 0;

    public override void Attack()
    {
        if (Time.time > mfNextShootTime && miCurrentAmminution > 0)
        {
            GameObject lNewBullet = Instantiate(mBulletPrefab, mShootPoint.position, mShootPoint.rotation);


            lNewBullet.GetComponent<Rigidbody>().AddForce(mShootPoint.forward * mfShootForce, ForceMode.Impulse);

            miCurrentAmminution--;
            mfNextShootTime = Time.time + mfTimeBetweenShoots;


        }
        else
        {
            Debug.Log(this.name + " no tiene munición");
        }

    }
}
