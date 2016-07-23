using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	enum platform {Android, IOS,Default}
	platform currentPlatform = platform.Default;

	public float speed;
	public float maxPosition = 2.4f;

	private UIManager UIM;
	private Vector2 position;
	private Rigidbody2D rb2D;
	// Use this for initialization
	void Start () {
		if (currentPlatform == platform.IOS) {
			print ("Current platform IOS");
		} else if (currentPlatform == platform.Android) {
			print ("Current platform is Android");
		} else {
			print ("Current platform is Default A.K.A Desktop");
		}
		rb2D = GetComponent<Rigidbody2D> ();
		UIM = GameObject.FindObjectOfType<UIManager> ();
		position = new Vector2 (transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {

		if (currentPlatform == platform.IOS) {
			//IOS shit
		} else {
			position.x += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;

		}
		position.x = transform.position.x;
		position.x = Mathf.Clamp (position.x, -maxPosition, maxPosition);
		transform.position = new Vector2 (position.x, position.y);
	}

	public void MoveLeft(){
		rb2D.velocity = new Vector2 (-speed, 0);
	}
	public void MoveRight(){
		rb2D.velocity = new Vector2 (speed, 0);
	}
	public void SetVelocityZero(){
		rb2D.velocity = Vector2.zero;
	}
	void Awake(){
		#if UNITY_IPHONE
		currentPlatform = platform.IOS;
		#elif UNITY_ANDROID
		currentPlatform = platform.Android;
		#else
		currentPlatform = platform.Default;
		#endif 
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
