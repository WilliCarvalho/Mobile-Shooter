using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject enemyPrefabs;
    public float minX, maxX, minZ, maxZ;
    public float minTime, maxTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Generate(Random.Range(minTime, maxTime)));
    }

    IEnumerator Generate(float time)
    {
        Vector3 p = new Vector3(
            Random.Range(minX, maxX), 
            transform.position.y, 
            Random.Range(minZ, maxZ));

        Instantiate(enemyPrefabs, p, transform.rotation);

        yield return new WaitForSeconds(time);
    }
}
