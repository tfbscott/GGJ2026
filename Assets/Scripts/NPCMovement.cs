using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NPCMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    public float speed = 2f;
    public float minTimeUntilChangeDir = 2.0f;
    public float maxTimeUntilChangeDir = 5.0f;
    public float minWaitAfterCollision = 1.0f;
    public float maxWaitAfterCollision = 2.0f;

    private Vector2 direction;

    private float timeUntilChangeDir = 0;
    private float timer = 0;

    private bool isMoving = true;
    private bool collided = false;
    private float waitAfterCollision = 0;
    private float collisionTimer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeUntilChangeDir = UnityEngine.Random.Range(minTimeUntilChangeDir, maxTimeUntilChangeDir);
        direction = UnityEngine.Random.insideUnitCircle;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsColliding()) return; // dont do anything if waiting after collision

        if (isMoving) // update direction if moving
        {
            CheckTimeUntilChangeDirValues();
            ChangeDirection();
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            Move();
        }
        else rb.linearVelocity = Vector2.zero;
    }

    void CheckTimeUntilChangeDirValues() // make sure time values make sense
    {
        if (maxTimeUntilChangeDir < minTimeUntilChangeDir)
            maxTimeUntilChangeDir = minTimeUntilChangeDir;

        if (minTimeUntilChangeDir < 0) minTimeUntilChangeDir = 1;
        if (maxTimeUntilChangeDir < 0) maxTimeUntilChangeDir = 1;
    }

    void ChangeDirection() // switches direction if timer is up
    {
        if (timer >= timeUntilChangeDir)
        {
            timeUntilChangeDir = UnityEngine.Random.Range(minTimeUntilChangeDir, maxTimeUntilChangeDir);
            direction = UnityEngine.Random.insideUnitCircle;
            timer = 0;
        }
        else timer += Time.deltaTime;
    }

    void Move()
    {
        if (direction != Vector2.zero) direction = direction.normalized;
        Vector2 targetVel = direction * speed;
        rb.linearVelocity = new Vector2(targetVel.x, targetVel.y);
    }

    private bool IsColliding()
    {
        if (collided == true) // if collide happened
        {
            if (collisionTimer >= waitAfterCollision) // if collision wait is over, continue moving in opposite direction
            {
                collided = false;
                timeUntilChangeDir = UnityEngine.Random.Range(minTimeUntilChangeDir, maxTimeUntilChangeDir);
                timer = 0;
                ReverseDirection();
                StartMoving();
                return false;
            }
            else collisionTimer += Time.deltaTime;
            return true;
        }
        else return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isMoving) // freeze if collided while moving
        {
            waitAfterCollision = UnityEngine.Random.Range(minWaitAfterCollision, maxWaitAfterCollision);
            StopMoving();
            collided = true;
            collisionTimer = 0;
        }
    }

    public void StartMoving()
    {
        Debug.Log("Moving");
        isMoving = true;
        //changes to walking animation
        anim.SetBool("Move", true);
    }

    public void StopMoving()
    {
        Debug.Log("Idle");
        isMoving = false;
        //changes to idle animation
        anim.SetBool("Move", false);
    }

    public void ReverseDirection()
    {
        direction = -direction;
    }
}