using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> adanaROADS = new List<GameObject>();
    [SerializeField] List<GameObject> enemyCars = new List<GameObject>();
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] float chaseModeRate = 25f;
    [SerializeField] private GameObject roadCamera;
    [SerializeField] private GameObject carParent;
    [SerializeField] private GameObject chaseCamera;
    [SerializeField] float roadLength = 84.0f;
    [SerializeField] float gameSpeed = 5.0f;
    [SerializeField] float enemySpawnRate = 10.0f;
    [SerializeField] TMP_Text healthText;
    PoliceSpawner spawner;
    private float spawnSpeed;
    private bool isSpawningEnemy;
    private bool chaseMode;

    public int health = 4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateHealth();
        HideCursor();
        Invoke("SpawnRoads",roadLength/gameSpeed-0.1f);
        spawner= FindObjectOfType<PoliceSpawner>();
        isSpawningEnemy = true;
        StartCoroutine(SpawnEnemyCars());
        StartCoroutine(GamePlanner());

    }

    private IEnumerator SpawnEnemyCars()
    {
        while (isSpawningEnemy)
        {
            SpawnEnemyCar();
            yield return new WaitForSeconds(enemySpawnRate);
        }
    }

    private void UpdateHealth()
    {
        healthText.text = "Health:" + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !chaseMode)
        {
            
            
            
        }

        if (Input.GetKeyDown(KeyCode.M) && !chaseMode)
        {
            SpawnEnemyCar();
        }
    }

    private IEnumerator GamePlanner()
    {
        while (true)
        {
             yield return new WaitForSeconds(chaseModeRate); 
             StartChaseMode();
        }
       
    }

    private void StartChaseMode()
    {
        chaseMode = true;
        isSpawningEnemy = false;
        StartChasing();
        spawner.Spawn();
        foreach (Transform child in carParent.transform)
        {
            // Child objeyi yok et
            Destroy(child.gameObject);
        }
        
        
    }

    void SpawnRoads()
    {
        
        Instantiate(adanaROADS[Random.Range(0,adanaROADS.Count)], transform.position, Quaternion.identity).transform.GetChild(0).GetComponent<RoadScript>().movementSpeed = gameSpeed;
        Invoke("SpawnRoads",roadLength/gameSpeed-0.1f);
    }


    public void SpawnEnemyCar()
    {
        Instantiate(enemyCars[Random.Range(0,enemyCars.Count)], spawnPoints[Random.Range(0,spawnPoints.Count)].position, Quaternion.Euler(0, 180, 0)).transform.SetParent(carParent.transform);
    }

    public void ChangeHealth(int amount)
    {
        if (health + amount > 0)
        {
            health += amount;
            UpdateHealth();
        }
        else
        {
            print("GAME OVER");
            health = 4;
        }
    }

    public void ChangeCameraLook(bool status)
    {
        chaseCamera.SetActive(status);
        roadCamera.SetActive(!status);
    }

    public void StopChasing()
    {
        ChangeCameraLook(false);
        HideCursor();
        chaseMode = false;
        isSpawningEnemy = true;
        StartCoroutine(SpawnEnemyCars());
    }

    public void StartChasing()
    {
        ChangeCameraLook(true);
        ShowCursor();
    }
    
    public void HideCursor()
    {
        Cursor.visible = false;       // İmleci görünmez yapar
        Cursor.lockState = CursorLockMode.Locked; // İmleci ekrana kilitler
    }

    // Cursor'u gösteren bir fonksiyon
    public void ShowCursor()
    {
        Cursor.visible = true;        // İmleci görünür yapar
        Cursor.lockState = CursorLockMode.None;  // İmleci serbest bırakır
    }

}
