using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlockManager : MonoBehaviour
{
    public int numFish;
    public GameObject fishPrefab;
    public GameObject leader;
    public GameObject[] allFish;
    public float minSpeed, maxSpeed, rotationSpeed, neighbourDistance;
    public float spawnArea;
    public bool leading;

    // Start is called before the first frame update
    void Start()
    {
        allFish = new GameObject[numFish];
        for (int i = 0; i < numFish; ++i)
        {
            Vector3 randPos;
            randPos.x = Random.Range(-spawnArea, spawnArea);
            randPos.y = Random.Range(-spawnArea, spawnArea);
            randPos.z = Random.Range(-spawnArea, spawnArea);
            Vector3 pos = this.transform.position + randPos; // random position

            Vector3 randomize; // random vector direction
            randomize.x = Random.Range(0.0f, 360.0f);
            randomize.y = Random.Range(0.0f, 360.0f);
            randomize.z = Random.Range(0.0f, 360.0f);
            allFish[i] = (GameObject)Instantiate(fishPrefab, pos,
                                Quaternion.LookRotation(randomize));
            allFish[i].GetComponent<Flock>().myManager = this;
        }
    }

}
