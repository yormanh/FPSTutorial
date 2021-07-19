using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    DamageableCharacter mDamageableCharacter;
    [SerializeField] Image mLifeBarImage;

    // Start is called before the first frame update
    void Start()
    {
        mDamageableCharacter = GetComponentInParent<DamageableCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        float lfCurrentLife = mDamageableCharacter.GetCurrentLife();
        float lfMaxLife = mDamageableCharacter.GetMaxLife();

        mLifeBarImage.fillAmount = lfCurrentLife / lfMaxLife;
    }
}
