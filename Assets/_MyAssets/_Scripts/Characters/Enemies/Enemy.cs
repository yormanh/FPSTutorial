using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : DamageableCharacter
{
    [SerializeField] GameObject mExplosionPrefab;

    float mfLifeTime = 3.0f;


    protected override void Die()
    {
        base.Die();

        Destroy(this.gameObject);

        GameObject lNewExplosion = Instantiate(mExplosionPrefab, this.transform.position, Quaternion.identity);
        Destroy(lNewExplosion, mfLifeTime);

    }

}
