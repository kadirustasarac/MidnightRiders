using UnityEngine;

public class Wheels: MonoBehaviour
{
    public float rotationSpeed = 100f; // Döndürme hızı

    void Update()
    {
        // Z ekseni etrafında sürekli dönme
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}