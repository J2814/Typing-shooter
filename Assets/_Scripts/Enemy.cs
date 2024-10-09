using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Target
{
    public GameObject deathEffectPrefab;

    public float Seconds;
    void Start()
    {
        StartCoroutine(AttackWithDelay(Seconds));
    }

    void Update()
    {

    }

    private void Attack()
    {
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
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        }

        base.Die();
    }
}
