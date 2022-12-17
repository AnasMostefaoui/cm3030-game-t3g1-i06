using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    public TeleporterController TeleporterController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider switchPlatform)
    {

        Debug.Log("Colliding");
        if (switchPlatform.gameObject.CompareTag("teleporter-big"))
        {
            TeleporterController.bigPlayerIsLocked = true;
        } else if (switchPlatform.gameObject.CompareTag("teleporter-small"))
        {
            TeleporterController.smallPlayerPlayerIsLocked = true;
        }

        if(switchPlatform.gameObject.CompareTag("teleporter-big") || switchPlatform.gameObject.CompareTag("teleporter-small"))
        {
            this.transform.position = new Vector3(switchPlatform.gameObject.transform.position.x, this.transform.position.y, switchPlatform.gameObject.transform.position.z);
            this.GetComponent<MovementController>().enabled = false;
        }
    }

}
