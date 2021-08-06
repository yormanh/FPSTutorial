using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Player : DamageableCharacter
{

    BaseWeapon mEquippedWeapon;
    BaseWeapon[] mAllWeapons;

    InputActionAsset mActionAsset = null;

    Keyboard mKeyboard;

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

        mAllWeapons = GetComponentsInChildren<BaseWeapon>(includeInactive: true);
        mEquippedWeapon = GetComponentInChildren<BaseWeapon>(); //primera que está activa

        foreach (BaseWeapon lBaseWeapon in mAllWeapons)
            lBaseWeapon.gameObject.SetActive(false);
        mEquippedWeapon.gameObject.SetActive(true);
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

        mKeyboard = Keyboard.current;

    }

    // Update is called once per frame
    void Update()
    {
        if (mbIsDead)
            Die();


        ChangeWeapon();

    }

    private void ChangeWeapon()
    {
        for (int i = 0; i < mAllWeapons.Length; i++)
        {
            int liKeyToCheck = i + 1;

            switch (liKeyToCheck)
            {
                case 1: if (mKeyboard.digit1Key.wasPressedThisFrame) ActivateWeapon(i); break;
                case 2: if (mKeyboard.digit2Key.wasPressedThisFrame) ActivateWeapon(i); break;
                case 3: if (mKeyboard.digit3Key.wasPressedThisFrame) ActivateWeapon(i); break;
                case 4: if (mKeyboard.digit4Key.wasPressedThisFrame) ActivateWeapon(i); break;
                case 5: if (mKeyboard.digit5Key.wasPressedThisFrame) ActivateWeapon(i); break;
                case 6: if (mKeyboard.digit6Key.wasPressedThisFrame) ActivateWeapon(i); break;
                case 7: if (mKeyboard.digit7Key.wasPressedThisFrame) ActivateWeapon(i); break;
                case 8: if (mKeyboard.digit8Key.wasPressedThisFrame) ActivateWeapon(i); break;
                case 9: if (mKeyboard.digit9Key.wasPressedThisFrame) ActivateWeapon(i); break;
            }

        }
    }

    private void ActivateWeapon(int i)
    {
        mEquippedWeapon.gameObject.SetActive(false);
        mEquippedWeapon = mAllWeapons[i];
        mEquippedWeapon.gameObject.SetActive(true);
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
