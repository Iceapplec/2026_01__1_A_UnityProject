using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinPrefabs;
    public GameObject MissilePrefabs;

    [Header("스폰 타이밍 설정")]
    public float minSpawnInterval = 0.5f;
    public float maxSpawnInterval = 2.0f;

    [Header("동전 스폰 확률 설정")]
    [Range(0, 100)]
    public int coinSpawnChance = 50;

    public float timer = 0.0f;
    public float nextSpawnTime;

    private void Start()
    {
        SetNextSpawnTIme();        
    }

    private void Update()
    {
        timer += Time.deltaTime;                           //시간이 0에서 점점 증가

        if(timer > nextSpawnTime)
        {
            SpawnObject();
            timer = 0.0f;                                  //시간을 초기화 시켜준다
            SetNextSpawnTIme();
        }
    }


    void SpawnObject()
    {
        Transform spawnTransform = transform;

        int randomValue = Random.Range(0, 100);

        if( randomValue < coinSpawnChance)
        {
            Instantiate(coinPrefabs, spawnTransform.position, spawnTransform.rotation);
        }
        else
        {
            Instantiate(MissilePrefabs, spawnTransform.position, spawnTransform.rotation);
        }

        
    }

    void SetNextSpawnTIme()
    {
        nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);    //랜덤 함수를 통해 nextSpawnTIme에 시간설정
    }


}
