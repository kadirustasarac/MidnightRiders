using UnityEngine;
using Unity.Cinemachine;
public class CreateImpulse2 : MonoBehaviour
{
    private CinemachineImpulseSource impulseSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShakeThatBooty()
    {
        impulseSource.GenerateImpulse();
    }
}
