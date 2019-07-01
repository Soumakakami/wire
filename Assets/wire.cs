using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wire : MonoBehaviour
{
	Rigidbody rigidbody;

	// Start is called before the first frame update
	void Start()
	{
		rigidbody = transform.parent.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	void RayHitWall()
	{
		Ray ray = new Ray(transform.position);
	}
}
