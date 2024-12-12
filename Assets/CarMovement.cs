using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour
{
    private Animator animator; // Animator bileşeni
    public float moveSpeed = 5f; // Hareket hızı
    [SerializeField] private float leftOffside = 8;
    [SerializeField] private float rightOffside = 7;

    private void Start()
    {
        // Animator bileşenini al
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Sağ ok tuşuna basıldığında sağa hareketi başlat
        if (Input.GetKeyDown(KeyCode.D) && transform.position.z <= leftOffside)
        {
            MoveRight();
        }if (Input.GetKeyDown(KeyCode.A) && transform.position.z >= -rightOffside)
        {
            MoveLeft();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("JUMP");
        }
    }

    public void MoveRight()
    {
        // Sağ animasyonunu başlat
        animator.SetTrigger("RIGHT");
        


    }
    public void MoveLeft()
    {
        // Sağ animasyonunu başlat
        animator.SetTrigger("LEFT");
    }

    public void ResetRotation()
    {
        transform.rotation = Quaternion.identity;
    }

    public void ResetHeight()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, 2.454934f, transform.localPosition.z);
    }



}