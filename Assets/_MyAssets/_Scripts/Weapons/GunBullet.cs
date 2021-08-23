using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : MonoBehaviour
{
    [SerializeField] float mfLifeTime = 3.0f;
    [SerializeField] string msTargetTag = "Enemy";

    int miDamage;

    public int GetDamage ()
    {
        return miDamage;
    }

    public void SetDamage(int value)
    {
        miDamage = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, mfLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("hit: " + other.name);

        if (other.CompareTag(msTargetTag))
        {
           if (other.GetComponent<DamageableCharacter>() != null)
            {
                //Destroy(other.gameObject);
                other.GetComponent<DamageableCharacter>().TakeDamage(miDamage);
            }
           else if (other.GetComponentInParent<DamageableCharacter>() != null)
            {
                other.GetComponentInParent<DamageableCharacter>().TakeDamage(miDamage);
            }

        }

        Destroy(this.gameObject);
    }
}
