using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.SceneManagement;

public class Player : DamageableCharacter
{

    BaseWeapon mEquippedWeapon;


    public BaseWeapon GetEquippedWeapon()
    {
        return mEquippedWeapon;
    }

    private void SetEquippedWeapon(BaseWeapon value)
    {
        mEquippedWeapon = value;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        mEquippedWeapon = GetComponentInChildren<BaseWeapon>();
        Cursor.visible = false;

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


    protected override void Die()
    {
        base.Die();

        this.enabled = false;
        this.GetComponent<FirstPersonController>().enabled = true;

        Invoke("ShowGameOver", 2);

    }

    void ShowGameOver()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadScene("GameOver");
    }
}
