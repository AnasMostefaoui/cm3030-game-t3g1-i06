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

    // True allows healing when in range
    public bool allowSpiritLinkHeal = true;

    // Check if the characters are close enough to link
    public bool hasSpiritLink = false;

    // Rate of change
    public float rateOfSpiritIncrease = 5.0f;
    public float rateOfSpiriTDecrease = 2.0f;

    // Collider for spirit Range
    public float spiritLinkRange = 6.0f;

    // activate or deactivate spirit link
    public UnityEvent toggleSpiritLink;

    // The line showing the visual spirit link
    public bool spiritLineActive = false;
    public GameObject spiritLineObj;
    LineRenderer spiritLine;

    GameObject humanChar;
    GameObject ghostChar;

    private void Start()
    {
        // Set the spirit health to max
        spiritHealth = maxSpiritHealth;

        // initialise the spirit link line
        spiritLine = spiritLineObj.GetComponent<LineRenderer>();

        // initialise character object references
        humanChar = GameManager.Instance.GetHumanPlayer();
        ghostChar = GameManager.Instance.GetGhostPlayer();
    }

    private void Update()
    {
        // Game over if spirt health runs out
        if (spiritHealth <= 0 )
        {
            GameManager.Instance.isGameOver = true;
        }

        // Update spirit link line position
        UpdateSpiritLinePos();

        // Handles automatic increases and decreases
        UpdateSpiritHealth();
    }

    public void EnableSpiritLine()
    {
        if (spiritLineActive)
        {
            spiritLine.enabled = true;
        }
    }

    public void BreakSpiritLine()
    {
        if (spiritLineActive)
        {
            // Get midpoint between human and ghost
            Vector3 particlePos = (humanChar.transform.position + ghostChar.transform.position) / 2;

            // Set particle emitter to midpoint
            spiritLineObj.transform.position = particlePos + Vector3.up;

            // Play the particle explosion
            spiritLineObj.GetComponent<ParticleSystem>().Play();

            spiritLine.enabled = false;
        }
    }

    private void UpdateSpiritLinePos()
    {
        if (spiritlinkActive && spiritLineActive)
        {
            // Get character positions
            Vector3 playerPos = humanChar.transform.position;
            Vector3 ghostPos = ghostChar.transform.position;

            // Set the line position
            spiritLine.SetPosition(0, playerPos + new Vector3(0, 1.8f, 0));
            spiritLine.SetPosition(1, ghostPos + new Vector3(0, 0.8f, 0));
        }
    }

    private void UpdateSpiritHealth()
    {
        // Check the spirit link is in use
        if (spiritlinkActive)
        {
            // Add or remove spirit health depending on spirit link
            if (hasSpiritLink && spiritHealth < maxSpiritHealth && allowSpiritLinkHeal)
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
