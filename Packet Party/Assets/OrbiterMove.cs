using UnityEngine;
using System.Collections;

public class OrbiterMove : MonoBehaviour {
	public Vector3 axis = Vector3.up; //rotate around Z
	public Vector3 newPos; //the next move location
	public float radius = 1.0f, radiusSpeed = 88f, rotationSpeed = 48.0f; //params


	// Use this for initialization
	void Start () {
		//transform.position = (transform.position - center.position).normalized * radius + center.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (transform.parent.position,axis,rotationSpeed*Time.deltaTime);
		newPos = (transform.position - transform.parent.position).normalized * radius + transform.parent.position;
		transform.position = Vector3.MoveTowards (transform.position,newPos,Time.deltaTime*radiusSpeed);
	}
}
