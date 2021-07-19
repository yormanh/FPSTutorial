using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour
{
    [SerializeField] protected int miMaxLife = 100;
    protected int miCurrentLife;
    protected bool mbIsDead = false;

    
    protected virtual void Start()
    {
        miCurrentLife = miMaxLife;
    }

    
    public void TakeDamage(int liDamage)
    {
        miCurrentLife -= liDamage;

        miCurrentLife = Mathf.Clamp(miCurrentLife, 0, miMaxLife);

        if (miCurrentLife == 0)
            Die();

    }

    protected virtual void Die()
    {
        mbIsDead = true;
    }

    protected void Heal (int liHeal)
    {
        if (!mbIsDead)
        {
            miCurrentLife += liHeal;
            miCurrentLife = Mathf.Clamp(miCurrentLife, 0, miCurrentLife);
        }    
    }

}
