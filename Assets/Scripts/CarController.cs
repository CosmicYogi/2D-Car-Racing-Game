using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	public float speed;
	public float maxPosition = 2.4f;
	Vector2 position;
	// Use this for initialization
	void Start () {
		position = new Vector2 (transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		position.x += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		position.x = Mathf.Clamp (position.x, -maxPosition, maxPosition);
		transform.position = new Vector2 (position.x, position.y);
	}
}
