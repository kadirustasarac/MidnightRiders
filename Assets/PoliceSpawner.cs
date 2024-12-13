using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{
    [SerializeField] GameObject policePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        Instantiate(policePrefab, transform.position, Quaternion.identity);
    }
}
