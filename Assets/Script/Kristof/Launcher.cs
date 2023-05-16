using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject[] projectile;
    public GameObject[] spawners;
    public float power = 5.0f;
    private float nextSpawnTime;
    public float secondsBetweenSpawning = 0.1f;

    void Start()
    {
        nextSpawnTime = Time.time + secondsBetweenSpawning;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            MakeThingToSpawn();
            nextSpawnTime = Time.time + secondsBetweenSpawning;
        }
    }

    void MakeThingToSpawn()
    {
        int spawnpoint = Random.Range(0, spawners.Length);
        int objectToSpawn = Random.Range(0, projectile.Length);
        if (spawners[spawnpoint])
        {
            if (projectile[objectToSpawn])
            {
                GameObject spawnedObject = Instantiate(projectile[objectToSpawn], spawners[spawnpoint].transform.position + spawners[spawnpoint].transform.forward, spawners[spawnpoint].transform.rotation) as GameObject;
                if (!spawnedObject.GetComponent<Rigidbody>())
                {
                    spawnedObject.AddComponent<Rigidbody>();
                }
                spawnedObject.GetComponent<Rigidbody>().AddForce(spawners[spawnpoint].transform.forward * power, ForceMode.VelocityChange);
                spawnedObject.transform.parent = gameObject.transform;
            }
        }
    }
}
