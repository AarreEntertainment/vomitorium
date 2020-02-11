using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyGroups;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newGroup = Instantiate(enemyGroups[Random.Range(0, enemyGroups.Length)]);
        newGroup.transform.position = transform.position;
        newGroup.transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
