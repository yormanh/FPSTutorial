using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAttack : MonoBehaviour
{
    [SerializeField] Transform mTurretPivot;
    [SerializeField] Transform mShootPoint;

    [SerializeField] int miDamage = 10;
    [SerializeField] Rigidbody mBulletPrefab;
    [SerializeField] float mfTimeBetweenShoots = 3f;
    [SerializeField] float mfAttackDistance = 50f;
    [SerializeField] float mfShootForce = 50f;


    Transform mPlayer;
    bool mbShooting;
    float mfTimeToShoot;

    void Start()
    {
        mPlayer = GameObject.FindWithTag("Player").transform;
    }

    
    void Update()
    {
        Vector3 lPlayerPosition = mPlayer.position;
        lPlayerPosition.y = lPlayerPosition.y + 1;

        mTurretPivot.LookAt(lPlayerPosition);

        float lfDistanceToPlayer = Vector3.Distance(this.transform.position, mPlayer.transform.position);

        if (lfDistanceToPlayer < mfAttackDistance)
        {
            if (Time.time > mfTimeToShoot)
            {
                Rigidbody lNewBullet = Instantiate(mBulletPrefab, mShootPoint.position, mShootPoint.rotation);
                lNewBullet.AddForce(mShootPoint.forward * mfShootForce, ForceMode.Impulse);
                lNewBullet.GetComponent<GunBullet>().SetDamage(miDamage);

                mfTimeToShoot = Time.time + mfTimeBetweenShoots;
            }
        }

    }
}
