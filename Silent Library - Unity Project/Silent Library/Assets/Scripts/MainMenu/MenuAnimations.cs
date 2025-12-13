using System.Drawing;
using NUnit.Framework.Constraints;
using UnityEngine;

public class MenuAnimations : MonoBehaviour
{
    public Animator animator;
    public GameObject playerModel;

    public Transform pointA;
    public Transform pointB;

    public Vector3 nextPosition;

    public int moveSpeed = 2;

    void Start()
    {
        nextPosition = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isRunning", true);
        
        playerModel.transform.position = Vector3.MoveTowards(playerModel.transform.position, nextPosition, moveSpeed * Time.deltaTime);

        if (playerModel.transform.position == nextPosition)
        {
            nextPosition = (nextPosition == pointA.position) ? pointB.position : pointA.position;
        }

        if (playerModel.transform.position == pointB.position)
        {
            playerModel.transform.eulerAngles = new Vector2(0,180);
        }
        else if (playerModel.transform.position == pointA.position)
        {
            playerModel.transform.eulerAngles = new Vector2(0,0);
        }
    }
}   

