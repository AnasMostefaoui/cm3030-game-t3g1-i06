using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpiritManager : MonoBehaviour
{
    // Starting spirit health
    public float maxSpiritHealth = 100f;
    // Current spirit health
    public float spiritHealth;

    // Keep track of spirit link being active
    public bool spiritlinkActive = false;

    // Check if the characters are close enough to link
    public bool hasSpiritLink = false;

    // Rate of change
    public float rateOfSpiritIncrease = 5.0f;
    public float rateOfSpiriTDecrease = 2.0f;

    // Collider for spirit Range
    public float spiritLinkRange = 6.0f;

    // activate or deactivate spirit link
    public UnityEvent toggleSpiritLink;

    // Game Over if no spirit link
    public UnityEvent gameOver;

    private void Start()
    {
        // Set the spirit health to max
        spiritHealth = maxSpiritHealth;
    }

    private void Update()
    {
        // Game over if spirt health runs out
        if (spiritHealth <= 0)
        {
            gameOver.Invoke();
            Time.timeScale = 0f;
        }

        // Handles automatic increases and decreases
        UpdateSpiritHealth();
    }

    private void UpdateSpiritHealth()
    {
        // Check the spirit link is in use
        if (spiritlinkActive)
        {
            // Add or remove spirit health depending on spirit link
            if (hasSpiritLink && spiritHealth < maxSpiritHealth)
            {
                IncreaseSpiritHealth((Time.deltaTime * rateOfSpiritIncrease));
            }
            else if (!hasSpiritLink && spiritHealth >= 0)
            {
                DecreaseSpiritHealth((Time.deltaTime * rateOfSpiriTDecrease));
            }
        }
    }
    // Turns the spirit link on or off
    public void ToggleSpiritLink()
    {
        Debug.Log("ToggleSpiritLink");
        if (spiritlinkActive)
        {
            spiritlinkActive = false;
            toggleSpiritLink.Invoke();
        }
        else
        {
            spiritlinkActive = true;
            toggleSpiritLink.Invoke();
        }
    }

    // Increase spirit health within range
    public void IncreaseSpiritHealth(float increaseAmount)
    {
        spiritHealth = Mathf.Clamp(spiritHealth + increaseAmount, 0, maxSpiritHealth);
    }

    // Decrease spirit health within range
    public void DecreaseSpiritHealth(float decreaseAmount)
    {
        spiritHealth = Mathf.Clamp(spiritHealth - decreaseAmount, 0, maxSpiritHealth);
    }
}
