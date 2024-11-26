using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficultyManager : MonoBehaviour
{
    // Start is called before the first frame update

    public float startSecondsAttack;
    public float startSecondsSpawn;
    
    public static float MainSecondsBeforeAttack;
    public TextAsset EasyWords;
    public TextAsset MediumWords;
    public TextAsset HardWords;
    public static TextAsset DiffText;
    void Awake()
    {
       SetDiffParams();
    }

    // Update is called once per frame
    void SetDiffParams() {

        //if (FindAnyObjectByType<MainMenuManager>() == null)
        //{
        //    DiffText = MediumWords; MainSecondsBeforeAttack = startSecondsAttack / ((float)(2.5)); Spawner.SpawnTime = startSecondsSpawn / ((float)(2.5));
        //    return;
        //}
        switch (MainMenuManager.difficulty)
        {
            case 0:
                DiffText = EasyWords; 
                MainSecondsBeforeAttack = startSecondsAttack; 
                Spawner.SpawnTime = startSecondsSpawn;
                //Debug.Log(startSecondsSpawn);
                break;
            case 1:
                DiffText = EasyWords; 
                MainSecondsBeforeAttack = startSecondsAttack / ((float)(2)); 
                Spawner.SpawnTime = startSecondsSpawn / ((float)(2));
                //Debug.Log(startSecondsSpawn);
                break;
            case 2:
                DiffText = MediumWords; 
                MainSecondsBeforeAttack = startSecondsAttack / ((float)(2.5)); 
                Spawner.SpawnTime = startSecondsSpawn / ((float)(2.5));
                //Debug.Log(startSecondsSpawn);
                break;
            case 3:
                DiffText = MediumWords; 
                MainSecondsBeforeAttack = startSecondsAttack / ((float)(3.5)); 
                Spawner.SpawnTime = startSecondsSpawn / ((float)(3.5));
                //Debug.Log(startSecondsSpawn);
                break;
            case 4:
                DiffText = HardWords; 
                MainSecondsBeforeAttack = startSecondsAttack / ((float)(5)); 
                Spawner.SpawnTime = startSecondsSpawn / ((float)(5));
                //Debug.Log(startSecondsSpawn);
                break;
        }

    }
}
