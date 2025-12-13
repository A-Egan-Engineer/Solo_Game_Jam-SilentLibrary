using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject enemy;
    int moveSpeed = 2;

    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public Transform pointD;

    Vector3 nextPosition;

    void Update()
    {
        EnemyPatrol();
    }

    public void EnemyPatrol()
    {
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, nextPosition, moveSpeed * Time.deltaTime);
        /*

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
        */
    }
}
