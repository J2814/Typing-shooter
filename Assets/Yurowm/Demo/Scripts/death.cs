using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestoyBody(5));
       
    }
    private IEnumerator DestoyBody(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
