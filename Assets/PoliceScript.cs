using System.Collections;
using UnityEngine;

public class PoliceScript : MonoBehaviour
{
    private Animator animator;
    [SerializeField] float chaseTime = 2f;
    [SerializeField] private float endChaseTime = 8f;
    CarMovement playerCar;
    SoundHandler soundHandler;
    private Direction direction = Direction.MIDDLE;
    public bool isChasing = true;

    public enum Direction
    {
        LEFT,
        RIGHT,
        MIDDLE
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("START");
        soundHandler = FindAnyObjectByType<SoundHandler>();

        playerCar = Object.FindAnyObjectByType<CarMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            GoToPlace(Direction.LEFT);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            GoToPlace(Direction.RIGHT);
        }
    }

    public void CarArrived()
    {
        StartCoroutine(ChasePlayer());
        Invoke("StopChasing", endChaseTime);
        print("COROUTINE STARTED");
    }

    public IEnumerator StopChasing()
    {
        yield return new WaitForSeconds(endChaseTime);
        isChasing = false;
    }

    private IEnumerator ChasePlayer()
    {
        StartCoroutine(StopChasing());
        while (isChasing)
        {
            if (playerCar.direction == CarMovement.Direction.MIDDLE && direction == Direction.LEFT)
            {
                GoToPlace(Direction.RIGHT);
            }
            if (playerCar.direction == CarMovement.Direction.MIDDLE && direction == Direction.RIGHT)
            {
                GoToPlace(Direction.LEFT);
            }
            if (playerCar.direction == CarMovement.Direction.LEFT && direction == Direction.MIDDLE)
            {
                GoToPlace(Direction.LEFT);
            }
            if (playerCar.direction == CarMovement.Direction.LEFT && direction == Direction.RIGHT)
            {
                GoToPlace(Direction.LEFT);
            }
            if (playerCar.direction == CarMovement.Direction.RIGHT && direction == Direction.MIDDLE)
            {
                GoToPlace(Direction.RIGHT);
            }
            if (playerCar.direction == CarMovement.Direction.RIGHT && direction == Direction.LEFT)
            {
                GoToPlace(Direction.RIGHT);
            }
            yield return new WaitForSeconds(chaseTime);
            
        }

        animator.SetTrigger("SHOOT");
        soundHandler.Laser();
        isChasing = true;
    }

    public void GoToPlace(Direction gothere)
    {
        if(direction == Direction.MIDDLE && gothere == Direction.LEFT)
        {
            animator.SetTrigger("GOLEFT");
            direction = Direction.LEFT;
        }
        if(direction == Direction.MIDDLE && gothere == Direction.RIGHT)
        {
            animator.SetTrigger("GORIGHT");
            direction = Direction.RIGHT;
        }
        
        
        if(direction == Direction.RIGHT && gothere == Direction.LEFT)
        {
            animator.SetTrigger("GOLEFT");
            direction = Direction.MIDDLE;
        }
        if(direction == Direction.LEFT && gothere == Direction.RIGHT)
        {
            animator.SetTrigger("GORIGHT");
            direction = Direction.MIDDLE;
        }
        
        
    }
}
