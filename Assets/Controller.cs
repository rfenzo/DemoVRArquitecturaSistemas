using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	public float rotationSpeed;
	public float axisSpeed;
	public float sizeSpeed;

	// Use this for initialization
	void Start () {
		rotationSpeed = 200f;
		axisSpeed = 0.06f;
		sizeSpeed = 0.04f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Y") && transform.position.y < 20) {
			transform.position += new Vector3(0f,axisSpeed,0f);        
        }
		if (Input.GetButton("A") && transform.position.y > transform.localScale.y / 2) {
			transform.position += new Vector3(0f,-axisSpeed,0f);        
        }
		if (Input.GetButton("X")) {        
            transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime);
        }
		if (Input.GetButton("B")) {        
            transform.Rotate (Vector3.down * rotationSpeed * Time.deltaTime);
        }

		
		float s = Input.GetAxis("BoxSize");
		bool cond1 = s > 0 && transform.localScale.y < 4 && transform.position.y - transform.localScale.y / 2 > 0;
		bool cond2 = s < 0 && transform.localScale.y > 0.2;
		if ( cond1 || cond2 ) {
			transform.localScale += new Vector3(s*sizeSpeed, s*sizeSpeed, s*sizeSpeed);
		}

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		transform.position += new Vector3(h*axisSpeed,0f,v*axisSpeed);
	}
}
