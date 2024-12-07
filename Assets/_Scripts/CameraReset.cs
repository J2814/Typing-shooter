using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReset : MonoBehaviour
{
    public GameObject TextCam;
    void Start()
    {
        StartCoroutine(ResetRoutine());
    }


    IEnumerator ResetRoutine()
    {
        TextCam.SetActive(false);
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        TextCam.SetActive(true);
    }
}
