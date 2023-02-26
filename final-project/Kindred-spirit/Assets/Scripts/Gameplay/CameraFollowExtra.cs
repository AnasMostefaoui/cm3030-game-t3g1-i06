using UnityEngine;
using System.Collections;

public class CameraFollowExtra : MonoBehaviour {
	public static CameraFollowExtra instance;

	// The target we are following
	public Transform target;
	// The distance in the x-z plane to the target
	public float distance = 10.0f;
	// the height we want the camera to be above the target
	public float height = 5.0f;

    public float rotationSpeed = 50f;

    public bool shouldRecenter = false;

    // Place the script in the Camera-Control group in the component menu
    [AddComponentMenu("Camera-Control/Smooth Follow")]

	void Awake()
	{
		if (instance == null)
			instance = this;
	}

    void Start()
    {
        CenterOnTarget();
    }


	void LateUpdate () 
	{
		// Early out if we don't have a target
		if (!target || GameManager.Instance.isPaused) return;

        if(shouldRecenter)
        {
            CenterOnTarget();
            shouldRecenter = false;
            return; 
        }
        var horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed  * Time.deltaTime ;
        var verticalInput = Input.GetAxis("Mouse Y") * rotationSpeed * -1 * Time.deltaTime;

        if(transform.position.y >= target.position.y && transform.position.y <= target.position.y + height)
        {
            transform.RotateAround(target.position, target.right, verticalInput);
        }

        transform.RotateAround(target.position, target.right, verticalInput);
        transform.RotateAround(target.position, target.up, horizontalInput);

        var clampedYPosition = Mathf.Clamp(transform.position.y, target.position.y, target.position.y + height);
        transform.position = new Vector3(transform.position.x, clampedYPosition, transform.position.z);
        // Always look at the target
        transform.LookAt(target);
 

    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        shouldRecenter = true;
    }

 
    public void CenterOnTarget()
    {
        if (target == null) return;
        var yRotation = Quaternion.Euler(0, target.eulerAngles.y, 0);
        var xRotation = Quaternion.Euler(target.eulerAngles.x, 0, 0);
        var currentHeight = target.position.y + height;

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        transform.position = target.position;
        transform.position -= yRotation * Vector3.forward * distance;
        transform.position -= xRotation * Vector3.right;

        // Set the height of the camera
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        // Always look at the target
        transform.LookAt(target);
    }
}
