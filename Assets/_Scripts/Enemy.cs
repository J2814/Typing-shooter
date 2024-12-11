using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Target
{
    public GameObject DeathEffectPrefab;

    public GameObject AttackEffectPrefab;
    private Actions anim;

    private Image AttackProgressBar;

    private float SecondsBeforeAttack = difficultyManager.MainSecondsBeforeAttack;
    void Start()
    {
        AttackProgressBar = GetComponentInChildren<Image>();
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

        AudioManager.instance.PlaySound(AudioManager.instance.SoundBank.EnemyShot);

        PlayerManager.RecieveDamage?.Invoke(1);
    }

    private IEnumerator Stay(float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.Stay();
    }
    private IEnumerator AttackWithDelay(float delay)
    {
        DOTween.To(() => AttackProgressBar.fillAmount, x => AttackProgressBar.fillAmount = x, 0, 0);
        DOTween.To(() => AttackProgressBar.fillAmount, x => AttackProgressBar.fillAmount = x, 1, delay);
        yield return new WaitForSeconds(delay);

        Attack();

        StartCoroutine(AttackWithDelay(SecondsBeforeAttack - 1));
        StartCoroutine(Stay(SecondsBeforeAttack));
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
