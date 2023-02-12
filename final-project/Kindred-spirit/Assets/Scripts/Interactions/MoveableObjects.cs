using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObjects : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
