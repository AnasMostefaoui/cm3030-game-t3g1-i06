using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterController : MonoBehaviour
{
    public GameObject bigPlayer;
    public GameObject smallPlayer;
    public bool bigPlayerIsLocked;
    public bool smallPlayerPlayerIsLocked;
    public bool isTeleporting;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bigPlayerIsLocked && smallPlayerPlayerIsLocked && !isTeleporting)
        {
            isTeleporting = true;
            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(3);
        var tempPosition = bigPlayer.transform.position;
        bigPlayer.transform.position = new Vector3(smallPlayer.gameObject.transform.position.x, bigPlayer.transform.position.y, smallPlayer.gameObject.transform.position.z);
        smallPlayer.transform.position = new Vector3(tempPosition.x, smallPlayer.transform.position.y, tempPosition.z);

        yield return new WaitForSeconds(1);
        isTeleporting = false;
        bigPlayerIsLocked = false;
        smallPlayerPlayerIsLocked = false;
    }
}
