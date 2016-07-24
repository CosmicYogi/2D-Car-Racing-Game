using UnityEngine;
using System.Collections;

public class AccleratorMove : MonoBehaviour {

	public float rotationSpeed = 3f;
	public float speed = 3f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float temp = Input.acceleration.x;
		float z = Input.acceleration.z;
		//print (temp);
		print(z);
		//transform.Translate (temp, 0, 0);
		Mathf.Clamp(temp,-1,1);
		transform.Translate (0, 0, -z);
		transform.Rotate(0,0,-temp*rotationSpeed);
	}
}
