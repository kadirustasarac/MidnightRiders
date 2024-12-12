using UnityEngine;

public class RoadScript : MonoBehaviour
{
    public float movementSpeed = 20f;

    public float destroyTime = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
    }
}
