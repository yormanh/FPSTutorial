using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : DamageableCharacter
{

    BaseWeapon mEquippedWeapon;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        mEquippedWeapon = GetComponentInChildren<BaseWeapon>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnAttack()
    {
        //Debug.Log("Attack");
        mEquippedWeapon.Attack();
    }

    private void OnReload ()
    {
        //Debug.Log("Reload");
        mEquippedWeapon.Reload();
    }
}
