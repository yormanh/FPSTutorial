using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject mExplosionPrefab;

    float mfLifeTime = 3.0f;


    public void TakeDamage()
    {
        Destroy(this.gameObject);

        GameObject lNewExplosion = Instantiate(mExplosionPrefab, this.transform.position, Quaternion.identity);
        Destroy(lNewExplosion, mfLifeTime);

    }

}
