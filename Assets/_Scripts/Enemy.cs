using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Target
{
    public GameObject DeathEffectPrefab;

    public GameObject AttackEffectPrefab;

    private float SecondsBeforeAttack = difficultyManager.MainSecondsBeforeAttack;
    void Start()
    {
        Init();
        StartCoroutine(AttackWithDelay(SecondsBeforeAttack));
        
    }

    void Update()
    {

    }

    private void Attack()
    {
        if (AttackEffectPrefab != null)
        {
            Instantiate(AttackEffectPrefab, transform.position, Quaternion.identity);
        }

        Debug.Log(this.name + " attacked");
        
        PlayerManager.RecieveDamage?.Invoke(1);
    }

    private IEnumerator AttackWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Attack();
    }

    internal override void Die()
    {
        if (DeathEffectPrefab != null)
        {
            Instantiate(DeathEffectPrefab, transform.position, Quaternion.identity);
        }
        base.Die();
    }
}
