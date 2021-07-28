using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{

    [SerializeField] protected int miMaxAmmunition = 8;
    [SerializeField] protected int miMaxInventoryAmmunition = 32;

    protected int miCurrentAmmunition;
    protected int miCurrentInvetoryAmmunition;

    [SerializeField] protected int miDamage = 10;
    [SerializeField] protected float mfTimeBetweenShoots = 0.2f;

    [SerializeField] bool mbInfiniteAmmunition = false;

    [SerializeField] AudioClip mReloadAudio;


    public bool GetInfiniteAmmunition()
    {
        return mbInfiniteAmmunition;
    }


    public int GetCurrentAmmunition()
    {
        return miCurrentAmmunition;
    }

    public int GetCurrentInvetoryAmmunition()
    {
        return miCurrentInvetoryAmmunition;
    }




    // Start is called before the first frame update
    void Start()
    {
        miCurrentAmmunition = miMaxAmmunition;
        miCurrentInvetoryAmmunition = miMaxAmmunition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Attack()
    {

        
    }

    public void Reload()
    {



        int liAmmunitionToReload = Mathf.Min(miMaxAmmunition - miCurrentAmmunition, miCurrentInvetoryAmmunition);

        if (liAmmunitionToReload > 0)
        {
            AudioSource.PlayClipAtPoint(mReloadAudio, this.transform.position);

            miCurrentAmmunition += liAmmunitionToReload;

            if (!mbInfiniteAmmunition)
                miCurrentInvetoryAmmunition -= liAmmunitionToReload;
        }
    }

    public virtual void PressTrigger()
    {

    }

    public virtual void ReleaseTrigger()
    {

    }
}
