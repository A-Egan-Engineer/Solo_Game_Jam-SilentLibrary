using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTrap : MonoBehaviour
{
    public InputAction trapSetBtn;
    public GameObject trapPrefab;
    public Transform trapSpawnPoint;
    public float trapCooldown = 15f;
    public float trapDuration = 5f;
    public AudioClip trapSetSound;
    public int maxTraps = 3;
    private int currentTraps;
    public bool canSetTrap;
    Vector3 spawnPosition;

    void Start()
    {
        trapSetBtn = InputSystem.actions.FindAction("Player/SetTrap");
        canSetTrap = true;
        currentTraps = 0;
    }

    void Update()
    {
        SetTrap();
    }

    public void SetTrap()
    {
        spawnPosition = new Vector3(transform.position.x, transform.position.y, -0.5f);

        if (canSetTrap)
        {
            if (trapSetBtn.WasPressedThisFrame() && currentTraps < maxTraps)
            {
                Instantiate(trapPrefab, spawnPosition, Quaternion.identity);
                AudioSource.PlayClipAtPoint(trapSetSound, transform.position);
                currentTraps++;
            }
        }
        else if (!canSetTrap)
        {
            Debug.Log("Trap is on cooldown.");
        }
    }
        
}
