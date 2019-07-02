using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wire : MonoBehaviour
{
	Rigidbody rigidbody;
	public GameObject cam;
	Vector3 left;
	Vector3 right;
	Vector3 t1;
	Vector3 t2;

	public GameObject leftWire;
	public GameObject rightWire;

	Vector3 direction;
	public LayerMask layer;
	public GameObject t;
	// Start is called before the first frame update
	void Start()
	{
		rigidbody = transform.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		RayHitWall();
	}
	void RayHitWall()
	{
		Ray ray = new Ray(cam.transform.position, cam.transform.forward);
		RaycastHit hit=new RaycastHit();
		Debug.DrawRay(ray.origin, ray.direction * 200.0f, Color.red, 0.0f);
		
		if (Input.GetKeyDown(KeyCode.A))
		{
			if (Physics.Raycast(ray, out hit, 100.0f,layer))
			{
				right = hit.point;
				t1 = hit.point;
				right.Normalize();
				
				Instantiate(t, hit.point, Quaternion.identity);
			}
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			if (Physics.Raycast(ray, out hit, 200.0f,layer))
			{
				left = hit.point;
				t2 = hit.point;
				left.Normalize();
				
				Instantiate(t,hit.point,Quaternion.identity);
			}
		}
		if (Input.GetKey(KeyCode.Space))
		{
			rigidbody.AddForce(direction*10,ForceMode.Force);
		}
		var dir = Vector3.Distance(transform.position,t1);
		var dir1 = Vector3.Distance(transform.position, t2);
		var aim = t1 - leftWire.transform.position;
		var look = Quaternion.LookRotation(aim);
		leftWire.transform.LookAt(t1);
		leftWire.transform.localScale = new Vector3(leftWire.transform.localScale.x, leftWire.transform.localScale.y, dir);
		rightWire.transform.LookAt(t2);
		rightWire.transform.localScale = new Vector3(rightWire.transform.localScale.x, rightWire.transform.localScale.y, dir1);
		direction = (left-transform.position) + (right - transform.position);
		Debug.Log(direction);
	}
}
