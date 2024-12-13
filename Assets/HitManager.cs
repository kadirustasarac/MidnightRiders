using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    [SerializeField] MeshRenderer component;
    [SerializeField] private float godTime = 2f;
    [SerializeField] private int repeats = 5;
    private bool isGod;
    private GameManager gm;
    private CreateImpulse2 impulse;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
        impulse = FindObjectOfType<CreateImpulse2>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator GodMode()
    {
        isGod = true;
        for (int i = 0; i < repeats; i++)
        {
            component.enabled = false;
            yield return new WaitForSeconds(godTime / 4);
            component.enabled = true;
            yield return new WaitForSeconds(godTime / 4);
        }

        isGod = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Laser" || other.tag == "EnemyCar") && !isGod)
        {
            impulse.ShakeThatBooty();
            StartCoroutine(GodMode());
            gm.ChangeHealth(-1);
        }

        print(other.gameObject.tag);
    }
}
