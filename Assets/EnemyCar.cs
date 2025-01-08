using System;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] SoundHandler soundHandler;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundHandler = FindAnyObjectByType<SoundHandler>();
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
            soundHandler.Explosion();
            Destroy(gameObject);
        }
    }
}
