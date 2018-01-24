using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshCollider))]

public class Lemming : MonoBehaviour {

	public enum modes {Catapult, Mover};

	private Vector3 screenPoint;
	private Vector3 offset;
	private MeshCollider LemmingCollider;
	private Vector3 mMouseUpPos, mMouseDownPos;
	private Rigidbody LemmingRB;
	private Camera theCam;
	private bool dragging;
	public modes mode;
	public int speed;

	public Vector3 gameObjectSreenPoint;
	public Vector3 mousePreviousLocation;
	public Vector3 mouseCurLocation;
	public Vector3 force;
	public Vector3 objectCurrentPosition;
	public Vector3 objectTargetPosition;
 	public float topSpeed = 10;

	// Use this for initialization
	void Start(){
		LemmingCollider = GetComponent<MeshCollider>();
		LemmingRB = GetComponent<Rigidbody>();
         theCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

	}
	
	// Update is called once per frame
	void Update(){
		
	}

 
	void OnMouseDown(){

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        if (mode == modes.Catapult){
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
			mMouseDownPos = Input.mousePosition;
		    dragging = true;
            mousePreviousLocation = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
        else{
            gameObjectSreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            //Sets the mouse pointers vector3
            mousePreviousLocation = new Vector3(Input.mousePosition.x, Input.mousePosition.y, gameObjectSreenPoint.z);
        }
	}
 
	void OnMouseDrag(){
        Vector3 curScreenPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        if (mode == modes.Catapult){
            force = curScreenPoint - mousePreviousLocation;
            mousePreviousLocation = curScreenPoint;
            LemmingRB.velocity += force;
        }
        else{
            mouseCurLocation = new Vector3(Input.mousePosition.x, Input.mousePosition.y, gameObjectSreenPoint.z);
            force = mouseCurLocation - mousePreviousLocation;//Changes the force to be applied
            mousePreviousLocation = mouseCurLocation;
            LemmingRB.velocity += (force * 0.2f);
        }
        var d = Input.GetAxis("Mouse ScrollWheel");

        if (d > 0f){
            transform.position = transform.position + (Camera.main.transform.forward * d * Time.deltaTime * 100f);
        }
        else if (d < 0f){
            transform.position = transform.position + (Camera.main.transform.forward * d * Time.deltaTime * 100f);
        }
    }

	void OnMouseUp(){
		if(mode == modes.Catapult){
			dragging = false;
			Vector3 left = theCam.transform.right *Input.GetAxis("Mouse X") * 10f;
			Vector3 right = theCam.transform.up *Input.GetAxis("Mouse Y") * 10f;
			Debug.Log(left);
			Debug.Log(right);
			GetComponent<Rigidbody>().AddForce(left, ForceMode.Impulse);
			GetComponent<Rigidbody>().AddForce(right, ForceMode.Impulse);
		} else{
			if (LemmingRB.velocity.magnitude > topSpeed)
		     		force = LemmingRB.velocity.normalized * topSpeed;
		}
		
     }

	public void FixedUpdate()
	{


	}	
}
