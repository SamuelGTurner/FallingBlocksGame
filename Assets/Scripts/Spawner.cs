using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour

{

    public GameObject fallingBlockPrefab;
    public Vector2 secondsBetweenSpawnsMinMax;
    public float nextSpawnTime;
    Vector2 screenHalfSizeWorldUnits;
    public Vector2 spawnSizeMinMax;
    public float spawnAngleMax;
    public Material BlockMaterial;

    // Start is called before the first frame update
    void Start()
    {

        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);

    }
    

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            // print(secondsBetweenSpawns);
            SpawnFallingBlock();
        }

    }

    void SpawnFallingBlock(){
        
        float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
        Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);

        float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
        float spawnAngleBias = spawnAngle - (spawnAngleMax * (spawnPosition.x / screenHalfSizeWorldUnits.x));

        GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngleBias));
        newBlock.transform.localScale = Vector3.one * spawnSize;

    }
}
