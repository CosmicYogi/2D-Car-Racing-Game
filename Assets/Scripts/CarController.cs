using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	public float speed;
	public float maxPosition = 2.4f;

	private UIManager UIM;
	private Vector2 position;
	// Use this for initialization
	void Start () {
		UIM = GameObject.FindObjectOfType<UIManager> ();
		position = new Vector2 (transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		position.x += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		position.x = Mathf.Clamp (position.x, -maxPosition, maxPosition);
		transform.position = new Vector2 (position.x, position.y);
	}

	void OnCollisionEnter2D(Collision2D coll){
		print ("collision happened");
		GameObject collidingCar = coll.gameObject as GameObject;
		if (collidingCar.GetComponent<EnemyCar> ()) {
			print ("Collided with Enemy car " + collidingCar.name);
			UIM.GameIsOver ();
			Destroy (gameObject);
		}
	}
}
