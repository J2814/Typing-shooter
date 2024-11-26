using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lights : MonoBehaviour
{
    public GameObject PointLight;
    void Start()
    {
        PointLight.SetActive(false);
        PointLight.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
