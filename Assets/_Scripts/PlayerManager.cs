using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private int hp = 3;
    public static Action<int> RecieveDamage;

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
