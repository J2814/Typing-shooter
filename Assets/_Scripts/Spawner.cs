using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<SpawnPoint> SpawnPoints = new List<SpawnPoint>();

    public List<GameObject> TargetPrefabs = new List<GameObject>();

    public Transform TargetHolder;
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    private GameObject GetRandomTarget(List<GameObject> Targets)
    {
        GameObject target = null;
        target = Targets[Random.Range(0, Targets.Count)];
        return target;
    }
    
    private SpawnPoint GetRandomSpawnPoint(List<SpawnPoint> spawnPoints) 
    {
        //Check is spawn point occupied

        //List<SpawnPoint> 

        SpawnPoint sp = spawnPoints[Random.Range(0, spawnPoints.Count)];
        return sp; 
    }

    private void SpawnTarget(GameObject target, SpawnPoint sp)
    {
        if (target.GetComponent<Target>() == null)
        {
            return;
        }
        Instantiate(target, TargetHolder);
        target.transform.position = sp.transform.position;
        sp.AssignTarget(target.GetComponent<Target>());

    }
}
