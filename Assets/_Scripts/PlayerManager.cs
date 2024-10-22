using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    public int hp = 3;
    public static Action<int> RecieveDamage;
    public static Action<int> HPChanged;

    public static Action PlayerKill;
    public static Action PlayerMiss;

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
        if (this.hp < 0)
        {
            this.hp = 0;
        }
        HPChanged?.Invoke(this.hp);
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
