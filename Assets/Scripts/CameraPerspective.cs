using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPerspective : MonoBehaviour {

	[Header("Camera Settings")]
	public int speed;	
	public GameObject target;
	

	private Vector3 point;

	// Use this for initialization
	void Start () {
		point = target.transform.position;
		// transform.LookAt(point);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow)) {
			transform.RotateAround(point, new Vector3(0.0f,1.0f,0.0f), speed * Time.deltaTime);
		} else if(Input.GetKey(KeyCode.RightArrow)) {
			transform.RotateAround(point, new Vector3(0.0f,-1.0f,0.0f), speed * Time.deltaTime);
		}
	}
}
