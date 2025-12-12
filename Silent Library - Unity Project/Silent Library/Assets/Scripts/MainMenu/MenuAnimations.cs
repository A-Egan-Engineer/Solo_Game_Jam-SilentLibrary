using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class MenuAnimations : MonoBehaviour
{
    public int moveSpeed = 2;
    public Animator animator;
    public GameObject playerModel;

    public Transform startPoint;
    public Transform endPoint;

    private bool movingToEndPoint;

    private bool movingToStartPoint;

    void Start()
    {
        movingToEndPoint = true;
        movingToStartPoint = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingToEndPoint)
        {
            playerModel.transform.position = Vector2.MoveTowards(playerModel.transform.position,endPoint.position, moveSpeed * Time.deltaTime);
            animator.SetBool("isRunning", true);
        }
        if (playerModel.transform.position == endPoint.position)
        {
            movingToEndPoint = false;
            movingToStartPoint = true;
        }
        if (movingToStartPoint)
        {
            playerModel.transform.position = Vector2.MoveTowards(playerModel.transform.position, startPoint.position, moveSpeed * Time.deltaTime);
            animator.SetBool("isRunning", true);
        }
    }   
}
