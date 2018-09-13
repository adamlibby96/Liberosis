using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    public float mouseSpeed = 3.0f;
    public float minVert = -80f;
    public float maxVert = 45f;

    private float rotX = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed; // * Time.deltaTime;
        if (mouseY != 0)
        {
            rotX -= mouseY;
            rotX = Mathf.Clamp(rotX, minVert, maxVert);

            float rotY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(rotX, rotY, 0);
        }
    }
}
