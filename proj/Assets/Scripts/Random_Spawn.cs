using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Spawn : MonoBehaviour
{
    public GameObject cubePrefab;
    private bool autoSpawn = true;
    [SerializeField] private float densityTime = .3f;
    [SerializeField] private float xOffset = 10f;
    [SerializeField] private float zOffset = 10f;

    void Update()
    {
        StartCoroutine(AutoSpawner());

        if(Input.GetKey(KeyCode.Space))
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(gameObject.transform.position.x-xOffset, gameObject.transform.position.x+xOffset), gameObject.transform.localPosition.y, Random.Range(gameObject.transform.position.z-zOffset, gameObject.transform.position.z+zOffset));
            Instantiate(cubePrefab, randomSpawnPosition, Quaternion.identity);
        }
    }

    IEnumerator AutoSpawner()
    {
        if(autoSpawn)
        {
            autoSpawn = false;
            yield return new WaitForSeconds(densityTime);
            // Vector3 randomSpawnPosition = new Vector3(Random.Range(gameObject.transform.position.x-10, gameObject.transform.position.x+11), 5, Random.Range(gameObject.transform.position.z-10, gameObject.transform.position.z+11));
            // Vector3 randomSpawnPosition = new Vector3(Random.Range(gameObject.transform.position.x-xOffset, gameObject.transform.position.x+xOffset), 0, Random.Range(gameObject.transform.position.z-zOffset, gameObject.transform.position.z+zOffset));
            Vector3 randomSpawnPosition = new Vector3(Random.Range(gameObject.transform.position.x-xOffset, gameObject.transform.position.x+xOffset), gameObject.transform.localPosition.y, Random.Range(gameObject.transform.position.z-zOffset, gameObject.transform.position.z+zOffset));
            Instantiate(cubePrefab, randomSpawnPosition, Quaternion.identity);
            autoSpawn = true;
        }
    }
}
