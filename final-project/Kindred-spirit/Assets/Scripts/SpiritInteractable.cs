using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritInteractable : MonoBehaviour
{
    // Radius that interactable can be consumed
    public float interactableRadius = 2f;
    // True if consumed
    public bool interactableConsumed = false;
    // Amount health can increase with interactable
    public float spiritIncrease = 20f;
    // Amount to increase per time step
    public float spiritIncreaseRate = 0.25f;
    // Timestep for each increase to be applied
    public float increasePerTime = 0.01f;

    void Update()
    {
        if (!interactableConsumed)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Get all the colliders within the radius
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactableRadius);
                // Check all the colliders hit for the player
                foreach (var hitCollider in hitColliders)
                {
                    if (hitCollider.tag == "Player" || hitCollider.tag == "GhostPlayer")           //TODO - Test GhostPlayer works when movement setup
                    {   
                        // Increase spirit by and amount at a speed
                        interactableConsumed = true;
                        // Consumer the interactable
                        StartCoroutine(ConsumeInteractable());
                    }
                }
            }
        }
    }

    IEnumerator ConsumeInteractable()
    {
        // Wait for the required time
        yield return new WaitForSeconds(increasePerTime);
        // Increase the spirit health
        GameManager.Instance.spiritManager.IncreaseSpiritHealth(spiritIncreaseRate);
        // Decrease the consumables increase amount
        spiritIncrease -= spiritIncreaseRate;
        // If spirit increase remains and we are not at max health, coroutine recurs
        if(spiritIncrease > 0 && GameManager.Instance.spiritManager.spiritHealth < GameManager.Instance.spiritManager.maxSpiritHealth)
        {
            StartCoroutine(ConsumeInteractable());
        }
    }
}
