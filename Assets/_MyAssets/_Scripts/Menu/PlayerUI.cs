using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] Image mLifeBar;
    [SerializeField] TextMeshProUGUI mAmmo;
    [SerializeField] Image mWeaponIcon;

    Player mPlayer;

    // Start is called before the first frame update
    void Start()
    {
        mPlayer = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        float lfCurrentLife = mPlayer.GetCurrentLife();
        float lfMaxLife = mPlayer.GetMaxLife();

        mLifeBar.fillAmount = lfCurrentLife / lfMaxLife;
            
    }
}
