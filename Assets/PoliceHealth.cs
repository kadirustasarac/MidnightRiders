using System;
using UnityEngine;
using UnityEngine.UI;

public class PoliceHealth : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] Image healthBar;
    [SerializeField] GameObject deathEffect;
    GameManager gm;
    CursorChanger cursorChanger;
    CreateImpulse impulse;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     gm = FindFirstObjectByType<GameManager>();
     cursorChanger = FindFirstObjectByType<CursorChanger>();
     impulse = FindFirstObjectByType<CreateImpulse>();
    }

    // Update is called once per frame
    void Update()
    {

        healthBar.fillAmount = health / 100;
    }

    private void OnMouseDown()
    {
        cursorChanger.Shoot();
        if (health >= 10)
        {
            health -= 10;
            impulse.ShakeThatBooty();
        }
        else
        { 
            impulse.ShakeThatBooty();
           DestroyCar(); 
        }
    }

    private void DestroyCar()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        gm.StopChasing();
        Destroy(gameObject);
    }
}
