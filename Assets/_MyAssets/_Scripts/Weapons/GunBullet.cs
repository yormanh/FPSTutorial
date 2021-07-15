using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : MonoBehaviour
{
    [SerializeField] float mfLifeTime = 3.0f;

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
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }

        Destroy(this.gameObject);
    }
}
