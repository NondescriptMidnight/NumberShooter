using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float speed = 1f;
    public float leftLock;
    public float rightLock;
    private float rotationZ;
    public float sensitivityZ = 15f;
    public float minimumZ = -60F;
    Quaternion originalRotation;
    public float maximumZ = 60F;

    private bool leftKeys = false;
    private bool rightKeys = false;
    private bool upKeys;
    private bool downKeys;

    // Use this for initialization
    void Start () {
        originalRotation = transform.localRotation;
    }
	
	// Update is called once per frame
	void Update ()
    {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {

                leftKeys = true;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {

                rightKeys = true;
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
            {
                leftKeys = false;
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            {
                rightKeys = false;
            }
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            rotationZ -= Input.GetAxis("Vertical") * sensitivityZ;
            rotationZ = ClampAngle(rotationZ, minimumZ, maximumZ);

            Quaternion xQuaternion = Quaternion.AngleAxis(rotationZ, new Vector3(1, 0, 0));
            transform.localRotation = originalRotation * xQuaternion;
        }
        if (leftKeys)
        {
            Vector3 position = this.transform.position;
            position.x -= 1 * speed * Time.deltaTime;
            this.transform.position = new Vector3(Mathf.Clamp(position.x, -leftLock, rightLock), transform.position.y, transform.position.z);
        }
        if (rightKeys)
        {
            Vector3 position = this.transform.position;
            position.x += 1 * speed * Time.deltaTime;
            this.transform.position = new Vector3(Mathf.Clamp(position.x, -leftLock, rightLock), transform.position.y, transform.position.z);
        }
    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}

