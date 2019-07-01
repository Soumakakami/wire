using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wire : MonoBehaviour
{
	Rigidbody rigidbody;
	public GameObject cam;
	Vector3 left;
	Vector3 right;
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
		Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.red, 0.0f);
		
		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(ray, out hit, 100.0f))
			{
				right = hit.point - transform.position;
				right.Normalize();
				Debug.Log(right);
				Instantiate(t, hit.point, Quaternion.identity);
			}
		}
		if (Input.GetMouseButtonDown(1))
		{
			if (Physics.Raycast(ray, out hit, 100.0f))
			{
				left = hit.point-transform.position;
				left.Normalize();
				Debug.Log(left);
				Instantiate(t,hit.point,Quaternion.identity);
			}
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			rigidbody.AddForce((left+right)*10.0f,ForceMode.Impulse);
		}
	}
}
