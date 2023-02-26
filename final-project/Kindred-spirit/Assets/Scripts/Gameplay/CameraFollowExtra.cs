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

	public float heightDamping = 2.0f;
    public float rotationSpeed = 50f;

    public float currentHeight = 0;

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
        if (target == null) return;
        var yRotation = Quaternion.Euler(0, target.eulerAngles.y, 0);
        var xRotation = Quaternion.Euler(target.eulerAngles.x, 0, 0);
        currentHeight = target.position.y + height;

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
	void LateUpdate () 
	{
		// Early out if we don't have a target
		if (!target || GameManager.Instance.isPaused) return;

        if(shouldRecenter)
        {
            ReCenterOnTarget();
            return; 
        }
        var horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed * -1 * Time.deltaTime;
        var verticalInput = Input.GetAxis("Mouse Y") * rotationSpeed * -1 * Time.deltaTime;

        // The look at will cause the camera to look into our object from top to down.
        // We rotate the camera to the original angle to avoid that
        var yRotation = Quaternion.Euler(0, transform.eulerAngles.y - horizontalInput, 0);
        var xRotation = Quaternion.AngleAxis(verticalInput * rotationSpeed, Vector3.right); 
        
        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        transform.position = target.position ;
        // go back to the original rotation set at Start
        transform.position -= yRotation * Vector3.forward * distance;

        currentHeight += verticalInput;

        //transform.RotateAround(transform.position, target.up, 90 * Time.deltaTime);
        // Always look at the target
        transform.LookAt(target);
        transform.RotateAround(transform.position, target.right, verticalInput * rotationSpeed * Time.deltaTime);
 

    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public void ReCenterOnTarget ()
    {

        transform.position = target.position - transform.position;
        shouldRecenter = false;

    }
}
