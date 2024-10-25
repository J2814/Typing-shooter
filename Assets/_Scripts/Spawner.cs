using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<SpawnPoint> SpawnPoints = new List<SpawnPoint>();

    public List<GameObject> TargetPrefabs = new List<GameObject>();

    public Transform TargetHolder;

    public float SpawnTime;

    public float SpawnSpeedUpTime;

    public float MinimumSpawnTime;

    private float currentSpawnTime;

    [SerializeField]
    private bool timedSpawn;

    void Start()
    {
        currentSpawnTime = SpawnTime;
        RandomSpawn();
    }

    void Update()
    {
        if (timedSpawn)
        {
            TimedSpawn();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            RandomSpawn();
        }

    }

    private void TimedSpawn()
    {
        currentSpawnTime -= Time.deltaTime;
        if (currentSpawnTime <= 0)
        {
            RandomSpawn();
            SpawnTime -= SpawnSpeedUpTime;
            if (SpawnTime < MinimumSpawnTime)
            {
                SpawnTime = MinimumSpawnTime;
            }
            currentSpawnTime = SpawnTime;
        }
    }
    private void RandomSpawn()
    {
        GameObject target = GetRandomTarget(TargetPrefabs);
        SpawnPoint spawnPoint = GetRandomSpawnPoint(SpawnPoints);
        SpawnTarget(target, spawnPoint);
    }

    private GameObject GetRandomTarget(List<GameObject> Targets)
    {
        GameObject target = null;
        target = Targets[Random.Range(0, Targets.Count)];
        return target;
    }
    
    private SpawnPoint GetRandomSpawnPoint(List<SpawnPoint> spawnPoints) 
    {
        SpawnPoint sp = null;

        List<SpawnPoint> notOccupiedSpawnPoints = new List<SpawnPoint>();
        
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (spawnPoints[i].OccupingTarget == null)
            {
                notOccupiedSpawnPoints.Add(spawnPoints[i]);
            }
        }

        if(notOccupiedSpawnPoints.Count > 0)
        {
            sp = notOccupiedSpawnPoints[Random.Range(0, notOccupiedSpawnPoints.Count)];
        }

        return sp; 
    }

    private void SpawnTarget(GameObject target, SpawnPoint sp)
    {
        if (target.GetComponent<Target>() == null)
        {
            return;
        }

        if (sp == null)
        {
            return;
        }

        GameObject spawnedTarget = Instantiate(target, TargetHolder);
        spawnedTarget.transform.position = sp.transform.position;
        sp.AssignTarget(spawnedTarget.GetComponent<Target>());

    }
}
