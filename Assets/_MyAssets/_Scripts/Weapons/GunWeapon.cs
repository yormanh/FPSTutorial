using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : BaseWeapon
{
    [SerializeField] GameObject mBulletPrefab;
    [SerializeField] Transform mShootPoint;

    [SerializeField] float mfShootForce = 50f;

    [SerializeField] AudioClip mShootAudio;
    [SerializeField] AudioClip mNoAmmo;


    float mfNextShootTime = 0;



    public override void Attack()
    {
        if (Time.time > mfNextShootTime)
        {
            ShootBullet();

        }
    }

    protected void ShootBullet()
    {
        if (miCurrentAmmunition > 0)
        {
            AudioSource.PlayClipAtPoint(mShootAudio, this.transform.position);

            GameObject lNewBullet = Instantiate(mBulletPrefab, mShootPoint.position, mShootPoint.rotation);


            lNewBullet.GetComponent<Rigidbody>().AddForce(mShootPoint.forward * mfShootForce, ForceMode.Impulse);

            lNewBullet.GetComponent<GunBullet>().SetDamage(miDamage);

            miCurrentAmmunition--;
            mfNextShootTime = Time.time + mfTimeBetweenShoots;


        }
        else
        {
            //Debug.Log(this.name + " no tiene munición");
            AudioSource.PlayClipAtPoint(mNoAmmo, this.transform.position);
        }
    }
}