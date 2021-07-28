using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Player : DamageableCharacter
{

    BaseWeapon mEquippedWeapon;

    InputActionAsset mActionAsset = null;

    public BaseWeapon GetEquippedWeapon()
    {
        return mEquippedWeapon;
    }

    private void SetEquippedWeapon(BaseWeapon value)
    {
        mEquippedWeapon = value;
    }

    private void Awake()
    {
        mActionAsset = GetComponent<PlayerInput>().actions;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        mEquippedWeapon = GetComponentInChildren<BaseWeapon>();
        Cursor.visible = false;

        var lTriggerPress = mActionAsset.FindActionMap("Player").FindAction("TriggerPress");
        lTriggerPress.Enable();

        lTriggerPress.performed += OnTriggerPress;
        lTriggerPress.canceled += OnTriggerPress;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerPress()
    {
        //Debug.Log("Attack");
        mEquippedWeapon.Attack();
    }

    private void OnTriggerPress(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            mEquippedWeapon.PressTrigger();
        }

        if (context.canceled)
        {
            mEquippedWeapon.ReleaseTrigger();
        }
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
