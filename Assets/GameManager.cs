using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> adanaROADS = new List<GameObject>();

    [SerializeField] float roadLength = 84.0f;
    [SerializeField] float gameSpeed = 5.0f;
    private float spawnSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("SpawnRoads",roadLength/gameSpeed-0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRoads()
    {
        
        Instantiate(adanaROADS[Random.Range(0,adanaROADS.Count)], transform.position, Quaternion.identity).transform.GetChild(0).GetComponent<RoadScript>().movementSpeed = gameSpeed;
        Invoke("SpawnRoads",roadLength/gameSpeed-0.1f);
    }

}
