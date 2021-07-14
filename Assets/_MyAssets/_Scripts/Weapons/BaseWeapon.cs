using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{

    [SerializeField] protected int miMaxAmmunition = 8;
    [SerializeField] protected int miMaxInventoryAmmunition = 32;

    protected int miCurrentAmminution;
    protected int miCurrentInvetoryAmmunition;

    [SerializeField] protected int miDamage = 10;
    [SerializeField] protected float mfTimeBetweenShoots = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        miCurrentAmminution = miMaxAmmunition;
        miCurrentInvetoryAmmunition = miMaxAmmunition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Attack()
    {

        
    }

    private void Reload()
    {

    }
}
