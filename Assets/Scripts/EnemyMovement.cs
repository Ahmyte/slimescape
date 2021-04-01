using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Direction direction;
    Rigidbody2D rigidbody2d;

    public float speed;
    public Transform leftPoint;
    public Transform rightPoint;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        leftPoint.transform.parent = transform.parent;
        rightPoint.transform.parent = transform.parent;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (direction == Direction.Left)
        {
            if (transform.position.x > leftPoint.position.x)
            {
                rigidbody2d.transform.position += Vector3.left * Time.deltaTime * speed;
            }
            else
            {
                direction = Direction.Right;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
            }
        }

        if (direction == Direction.Right)
        {
            if (transform.position.x < rightPoint.position.x)
            {
                rigidbody2d.transform.position += Vector3.right * Time.deltaTime * speed;
            }
            else
            {
                direction = Direction.Left;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(leftPoint.position, 0.1f);
        Gizmos.DrawWireSphere(rightPoint.position, 0.1f);
    }
}

enum Direction
{
    Left,
    Right
}
