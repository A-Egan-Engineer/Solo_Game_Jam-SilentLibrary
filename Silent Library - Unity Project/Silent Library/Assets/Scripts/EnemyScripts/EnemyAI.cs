using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject enemy;
    float moveSpeed = 1.5f;

    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public Transform pointD;

    Vector3 nextPosition;

    int detectionRange = 2;

    public Transform playerTransform;

    bool chasingPlayer;

    void Start()
    {
        nextPosition = pointA.position;
        chasingPlayer = false;
    }

    void Update()
    {
        ChasePlayer();
        EnemyPatrol();
    }

    public void EnemyPatrol()
    {
        if(!chasingPlayer)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, nextPosition, moveSpeed * Time.deltaTime);

        if (enemy.transform.position == nextPosition)
        {
            if (nextPosition == pointA.position)
            {
                nextPosition = pointB.position;
            }
            else if (nextPosition == pointB.position)
            {
                nextPosition = pointC.position;
            }
            else if (nextPosition == pointC.position)
            {
                nextPosition = pointD.position;
            }
            else if (nextPosition == pointD.position)
            {
                nextPosition = pointA.position;
            }
        }
        }
    }

    public void ChasePlayer()
    {
        if (Vector3.Distance(enemy.transform.position, playerTransform.position) > detectionRange)
        {
            chasingPlayer = false;
        }
        else
        {
            chasingPlayer = true;
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
        }        
    }
}
