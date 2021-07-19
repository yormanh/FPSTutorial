using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideAttack : MonoBehaviour
{
    [SerializeField] ParticleSystem mExplosionPrefab;
    [SerializeField] float mfAttackDistance = 2f;
    [SerializeField] int miDamage = 10;

    Transform mPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        mPlayer = GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        float lfDistance = Vector3.Distance(this.transform.position, mPlayer.position);

        if (lfDistance < mfAttackDistance)
        {

            //TODO: daño al jugador

            mPlayer.GetComponent<Player>().TakeDamage(miDamage);

            ParticleSystem lNewExplosion = Instantiate(mExplosionPrefab, this.transform.position, Quaternion.identity);

            //Destroy(lNewExplosion.gameObject, lNewExplosion.main.duration);
            Destroy(this.gameObject);
        }
    }
}
