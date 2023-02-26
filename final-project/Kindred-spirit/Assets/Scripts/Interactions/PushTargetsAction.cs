using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PushTargetsAction : MonoBehaviour
{
    private float pushingSpeed = 20f;
    public GameObject target;
    private GameObject player;
    private Mover playerMovementScript;

    private CharacterController playerController;
    private Animator playerAnimator;
    private bool isPushing = false;
    private bool cameraWasCentered = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = GetComponentInChildren<Animator>();
        playerController = GetComponent<CharacterController>();
        playerMovementScript = GetComponent<Mover>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPushing)
        {
            playerAnimator.SetBool("isPushing", false);
            playerAnimator.SetBool("isGrabing", false);
            return;
        }

        var inputVect = new Vector2(0, Input.GetAxis("Vertical"));
        inputVect.Normalize();


        playerAnimator.SetBool("isGrabing", playerController.velocity.magnitude <= 0);
        playerAnimator.SetBool("isPushing", playerController.velocity.magnitude > 0);
        //playerAnimator.SetFloat("direction", playerController.velocity.z < 0f ? 1 : -1);
        
        target.GetComponent<Rigidbody>().AddForce(
            player.transform.forward * inputVect.magnitude * pushingSpeed,
            ForceMode.Impulse);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Moveable")
        {
            DropMoveable();
            cameraWasCentered = false;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag != "Moveable")
        {
            return;
        }

        if (!Input.GetKey(KeyCode.Space) )
        {
            DropMoveable();
            cameraWasCentered = false;
            return;
        }


        player.GetComponent<Mover>().moveForwardOnly = true;
        playerMovementScript.isPushing = true;
        target = other.gameObject;
        isPushing = true;


        // no up movement allowed
        var direction = target.transform.position - player.transform.position;
        direction.y = 0;
        // make the player look straight to the moveable
        player.transform.rotation = Quaternion.LookRotation(direction);
        if (!cameraWasCentered)
        {   // bring the camera behind the player
            var camera = FindObjectOfType<CameraFollow>();
            camera.shouldRecenter = true;
            cameraWasCentered = true;
            camera.transform.rotation = Quaternion.LookRotation(direction);
        }


        if (other.gameObject.GetComponent<AudioSource>() != null)
        {
            other.gameObject.GetComponent<AudioSource>().enabled = true;
        }
    }

    private void DropMoveable()
    {
        isPushing = false;
        playerMovementScript.isPushing = false;
        player.GetComponent<Mover>().moveForwardOnly = false;
        if (target && target    .gameObject.GetComponent<AudioSource>() != null)
        {
            target.gameObject.GetComponent<AudioSource>().enabled = false;
        }
        target = null;
        return;
    }
}
