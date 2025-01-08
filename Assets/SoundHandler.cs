using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    [SerializeField] AudioClip phoneRing;
    [SerializeField] AudioClip talkSound;
    [SerializeField] AudioClip explodeSound;
    [SerializeField] AudioClip laserSound;
    [SerializeField] AudioClip shotSound;
    [SerializeField] AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PhoneRing()
    {
        audioSource.clip = phoneRing;
        audioSource.Play();
    }
    public void TalkSound()
    {
        audioSource.clip = talkSound;
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }

    public void Explosion()
    {
        audioSource.PlayOneShot(explodeSound);
    }

    public void Shoot()
    {
        audioSource.PlayOneShot(shotSound);
    }

    public void Laser()
    {
        audioSource.PlayOneShot(laserSound);
    }
    
}
