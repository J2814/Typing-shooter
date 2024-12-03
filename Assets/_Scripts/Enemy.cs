using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Target
{
    public GameObject DeathEffectPrefab;

    public GameObject AttackEffectPrefab;
    private Actions anim;
   
    private float SecondsBeforeAttack = difficultyManager.MainSecondsBeforeAttack;
    void Start()
    {
        Init();
        anim = GetComponent<Actions>();
        StartCoroutine(AttackWithDelay(SecondsBeforeAttack-1));
        StartCoroutine(Stay(SecondsBeforeAttack));
    }

    void Update()
    {

    }

    private void Attack()
    {
        if (AttackEffectPrefab != null)
        {
            anim.Attack();
            Instantiate(AttackEffectPrefab, transform.position, Quaternion.identity);
        }
        Debug.Log(this.name + " attacked");
        PlayerManager.RecieveDamage?.Invoke(1);
    }

    private IEnumerator Stay(float delay)
    {
        yield return new WaitForSeconds(delay);
      anim.Stay();
    }
    private IEnumerator AttackWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Attack();
    }
   
    internal override async void Die()
    {
        base.Die();
        if (DeathEffectPrefab != null)
        {
            Instantiate(DeathEffectPrefab,transform.position,transform.rotation);
           // DeathEffectPrefab.GetComponent<Actions>().Death();
        }
     
    }
}
