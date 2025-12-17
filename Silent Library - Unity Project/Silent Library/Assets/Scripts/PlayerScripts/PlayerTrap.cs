using System;
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
        if (canSetTrap)
        {
            if (trapSetBtn.WasPressedThisFrame() && currentTraps < maxTraps)
            {
                Instantiate(trapPrefab, transform.position, Quaternion.identity);
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
