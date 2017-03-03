using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
	Camera myCam;
	public float speed = 1.0f;
	public float horizontalSpeed = 2.0f;
	public float verticalSpeed = 2.0f;
	public float minDis = 15f;
	public float maxDis = 120f;
	public float sensitivity = 10f;


	Vector3 rotateTarget;
	Vector3 currentEuler;
	Vector3 rotateVelocity;

	// Use this for initialization
	void Start () {
		myCam = Camera.main;
		rotateTarget = myCam.transform.eulerAngles;
		currentEuler = myCam.transform.eulerAngles;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W)) {
			myCam.transform.Translate (Vector3.forward * speed * Time.deltaTime, Space.Self);
		}
		if (Input.GetKey(KeyCode.A)) {
			myCam.transform.Translate (Vector3.left * speed * Time.deltaTime, Space.Self);
		}
		if (Input.GetKey(KeyCode.S)) {
			myCam.transform.Translate (Vector3.back * speed * Time.deltaTime, Space.Self);
		}
		if (Input.GetKey(KeyCode.D)) {
			myCam.transform.Translate (Vector3.right * speed * Time.deltaTime, Space.Self);
		}
		if (Input.GetMouseButton(0)) {
			
		}
		if (Input.GetMouseButton(1)) {
			float inputx = -horizontalSpeed * Input.GetAxis ("Mouse Y");
			float inputY = verticalSpeed * Input.GetAxis ("Mouse X");
			rotateTarget += new Vector3 (inputx,inputY,0);
			rotateTarget.z = 0;
//			myCam.transform.Rotate (inputx, inputY, 0,Space.World);
			currentEuler = rotateTarget;
			myCam.transform.eulerAngles = currentEuler;
		}
		if (Input.GetMouseButton(2)) {
			float inputx = -horizontalSpeed * Input.GetAxis ("Mouse X");
			float inputY = -verticalSpeed * Input.GetAxis ("Mouse Y");
			myCam.transform.Translate (inputx*horizontalSpeed*Time.deltaTime, inputY*verticalSpeed*Time.deltaTime, 0,Space.Self);
		}

		if (Input.GetAxis ("Mouse ScrollWheel") != 0) {
			float distance = Input.GetAxis("Mouse ScrollWheel") * 5;
			myCam.transform.Translate (0, 0, distance, Space.Self);
//			myCam.transform.localPosition= new Vector3(myCam.transform.localPosition.x,myCam.transform.localPosition.y, distance);

		}
	}
}
