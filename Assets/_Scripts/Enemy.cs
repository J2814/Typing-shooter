using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Target
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Attack()
    {
        Debug.Log(this.name + " attacked");
    }
}
