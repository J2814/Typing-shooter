using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    public int hp = 3;
    public static Action<int> RecieveDamage;
    public static Action<int> HPChanged;

    public static Action PlayerKill;
    public static Action PlayerMiss;

    public GameObject LoseUI;
    public Spawner spawner;

    private void OnEnable()
    {
        RecieveDamage += reductHP;
    }

    private void OnDisable()
    {
        RecieveDamage -= reductHP;
    }
    public void reductHP(int hp)
    {
        this.hp -= hp;
        AudioManager.instance.PlaySound(AudioManager.instance.SoundBank.PlayerDamage);
        if (this.hp <= 0)
        {
            //this.hp = 0;
            GameOver();
            AudioManager.instance.PlaySound(AudioManager.instance.SoundBank.Gameover);
        }
        HPChanged?.Invoke(this.hp);
    }

    private void GameOver()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.SoundBank.Gameover);
        Time.timeScale = 0;
        LoseUI.SetActive(true);
        spawner.GameOver();
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Home))
        {
            Debug.Log("Current HP is" + hp);
            reductHP();
            Debug.Log("Current HP is" + hp);
        };
        */
    }
}
