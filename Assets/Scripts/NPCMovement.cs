using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public enum Direction { None, Up, Right, Down, Left }
    private enum Axis { X, Y };

    public float speed = 2f;
    public float minTimeUntilChangeDir = 2.0f;
    public float maxTimeUntilChangeDir = 5.0f;

    private (Direction, Direction) dir = (Direction.None, Direction.None);

    private float timeUntilChangeDir = 0;
    private float timer = 0;

    private bool isMoving = true;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeUntilChangeDir = UnityEngine.Random.Range(minTimeUntilChangeDir, maxTimeUntilChangeDir);
        dir = ((Direction)UnityEngine.Random.Range(0, 5), (Direction)UnityEngine.Random.Range(0, 5));
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            CheckTimeUntilChangeDirValues();
            ChangeDirection();
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            Move(dir.Item1, Axis.X);
            Move(dir.Item2, Axis.Y);
        }
        else rb.linearVelocity = Vector2.zero;
    }

    void CheckTimeUntilChangeDirValues()
    {
        if (maxTimeUntilChangeDir < minTimeUntilChangeDir)
            maxTimeUntilChangeDir = minTimeUntilChangeDir;

        if (minTimeUntilChangeDir < 0) minTimeUntilChangeDir = 1;
        if (maxTimeUntilChangeDir < 0) maxTimeUntilChangeDir = 1;
    }

    void ChangeDirection()
    {
        if (timer >= timeUntilChangeDir)
        {
            timeUntilChangeDir = UnityEngine.Random.Range(minTimeUntilChangeDir, maxTimeUntilChangeDir);
            dir = ((Direction)UnityEngine.Random.Range(0, 5), (Direction)UnityEngine.Random.Range(0, 5));
            timer = 0;
        }
        else timer += Time.deltaTime;
    }

    void Move(Direction dir, Axis axis)
    {
        Vector2 moveDir = Vector2.zero;
        switch (dir)
        {
            case Direction.Up:
                moveDir = Vector2.up;
                break;
            case Direction.Right:
                moveDir = Vector2.right;
                break;
            case Direction.Down:
                moveDir = Vector2.down;
                break;
            case Direction.Left:
                moveDir = Vector2.left;
                break;
            default: break;
        }
        moveDir = moveDir.normalized;
        Vector2 targetVel = moveDir * speed;

        if(axis == Axis.X)
        {
            rb.linearVelocity = new Vector2(targetVel.x, rb.linearVelocity.y);
        }
        else rb.linearVelocity = new Vector2(rb.linearVelocity.x, targetVel.y);
    }

    public void StartMoving()
    {
        isMoving = true;
    }

    public void StopMoving()
    {
        isMoving = false;
    }
}
