using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    public PlayerMovement PlayerMovement;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.isMoving == true)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
