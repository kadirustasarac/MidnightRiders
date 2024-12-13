using System;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] private GameObject explosionEffect;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity).GetComponent<EffectMover>().speed = speed;
            Destroy(gameObject);
        }
    }
}
