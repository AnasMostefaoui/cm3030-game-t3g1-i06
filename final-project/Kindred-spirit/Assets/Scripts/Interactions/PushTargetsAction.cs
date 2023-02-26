using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PushTargetsAction : MonoBehaviour
{
    private float pushingSpeed = 8f;
    public GameObject target;
    private GameObject player;

    private CharacterController playerController;
    private Animator playerAnimator;
    private bool isPushing = false;
    private Vector3 lockedForwardDirection;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = GetComponentInChildren<Animator>();
        playerController = GetComponent<CharacterController>();
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

        playerAnimator.SetBool("isRunning", false);

        if (inputVect.magnitude <= 0)
        {
            playerAnimator.SetBool("isGrabing", true);
            return;
        }
        playerAnimator.SetBool("isPushing", inputVect.magnitude > 0);
        playerAnimator.SetFloat("direction", playerController.velocity.z < 0f ? 1 : -1);
        
        target.GetComponent<Rigidbody>().AddForce(
            player.transform.forward * inputVect.magnitude * pushingSpeed,
            ForceMode.Impulse);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Moveable")
        {
            isPushing = false;
            target = null;
            if (other.gameObject.GetComponent<AudioSource>() != null)
            {
                other.gameObject.GetComponent<AudioSource>().enabled = false;
            }
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
            Debug.Log($"other.gameObject.tag {other.gameObject.tag} KeyCode: {Input.GetKey(KeyCode.Space)}");
            isPushing = false;
            target = null;
            player.GetComponent<Mover>().moveForwardOnly = false;
            if (other.gameObject.GetComponent<AudioSource>() != null)
            {
                other.gameObject.GetComponent<AudioSource>().enabled = false;
            }
            return;
        }

        isPushing = true;
        player.GetComponent<Mover>().moveForwardOnly = true;
        var camera = GameObject.FindObjectOfType<CameraFollowExtra>();
        camera.shouldRecenter = true;
        target = other.gameObject;
        var direction = target.transform.position - player.transform.position;
        direction.y = 0;

        player.transform.rotation = Quaternion.LookRotation(direction);

        if (other.gameObject.GetComponent<AudioSource>() != null)
        {
            other.gameObject.GetComponent<AudioSource>().enabled = true;
        }


    }
}
