using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    BaseWeapon mEquippedWeapon;

    // Start is called before the first frame update
    void Start()
    {
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
