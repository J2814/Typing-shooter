using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<SpawnPoint> SpawnPoints = new List<SpawnPoint>();

    public List<GameObject> TargetPrefabs = new List<GameObject>();

    public List<GameObject> BossTargetPrefabs = new List<GameObject>();

    public int ParBossSpawn;

    private int BossSpawn = 0;

    public Transform TargetHolder;

    public static float SpawnTime;

    public float SpawnSpeedUpTime;

    public float MinimumSpawnTime;

    private float currentSpawnTime;

    [SerializeField]
    private bool timedSpawn;

    private bool isGameOver = false;
    
    private bool SpawnPause=false;
    private SpawnPoint LastSPB = null;

    void Start()
    {
        currentSpawnTime = SpawnTime;
        RandomSpawn();
    }

    void Update()
    {
      //  Debug.Log(SpawnTime+"/"+ difficultyManager.MainStartSpawnTime);
        if (!isGameOver)
        {
            if (BossSpawn==ParBossSpawn)
            {
                SpawnPause = true;
            }
            if (timedSpawn)
            {
                TimedSpawn();
            }

            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                RandomSpawn();
            }
        }

    }

    public void GameOver()
    {
        isGameOver = true;
    }

    private void TimedSpawn()
    {
        if (SpawnPause==false) 
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
                BossSpawn++;

            }
        }
        else
        {
            if(LastSPB != null && LastSPB.OccupingTarget != null) {
            }
            else if (LastSPB!=null && LastSPB.OccupingTarget == null)
            {
                BossSpawn = 0; SpawnPause = false;
            }
           else if (BossSpawn == ParBossSpawn) 
            {
                SpawnPoint SPB = GetRandomSpawnPoint(SpawnPoints);
                RandomBossSpawn(SPB);
                
                Debug.Log("1f");
                LastSPB = SPB;
                SpawnPause = true;


            }
            if (CheckOccupiedAllSP(SpawnPoints)==true)
            {
                Debug.Log("2f");
                if (CheckOccupiedAllSP(SpawnPoints) == false)
                {
                    SpawnPause = false;
                }
            }
        }
    }

    private void RandomBossSpawn(SpawnPoint sp)
    {

        GameObject target = GetRandomTarget(BossTargetPrefabs);
        SpawnPoint spawnPoint = sp;
        SpawnTarget(target, spawnPoint);

    }
    private void RandomSpawn()
    {
       
            GameObject target = GetRandomTarget(TargetPrefabs);
            SpawnPoint spawnPoint = GetRandomSpawnPoint(SpawnPoints);

            SpawnTarget(target, spawnPoint);
       
    }
    private bool CheckOccupiedAllSP(List<SpawnPoint> spawnPoints) 
    {
        int countOccupiet = 0;
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (spawnPoints[i].OccupingTarget != null)
            {
                countOccupiet++;
            }
        }
        if (countOccupiet == spawnPoints.Count)
        {
            return true;
        }
        return false;
        
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
