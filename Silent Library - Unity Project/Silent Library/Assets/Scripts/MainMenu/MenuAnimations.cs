using UnityEngine;

public class MenuAnimations : MonoBehaviour
{
    public int moveSpeed = 2;
    public Animator animator;
    public GameObject playerModel;

    // Update is called once per frame
    void Update()
    {
        if (playerModel.transform.position.x <= 0f)
        {
            playerModel.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else if (playerModel.transform.position.x >= 4.8f)
        {
            playerModel.transform.eulerAngles = new Vector2(0, 180);
            playerModel.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }
        
}
