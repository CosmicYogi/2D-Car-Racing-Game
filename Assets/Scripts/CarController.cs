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
		print (PlayerPrefsManager.GetInputMethodOnTouchScreenMobileDevice ());
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
		if (currentPlatform == platform.IOS || currentPlatform == platform.Android) {
			if (PlayerPrefsManager.GetInputMethodOnTouchScreenMobileDevice () == "buttons") {
				MoveOnTouch ();
			} else if (PlayerPrefsManager.GetInputMethodOnTouchScreenMobileDevice () == "acclerometer") {
				MoveOnAcclerometer ();
			} else {
				//Would be working with both, This is because it's kind of a practice game. and TIME is very precious.
				MoveOnTouch();
				MoveOnAcclerometer ();
			}
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
	void MoveOnTouch(){
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			float middleX = Screen.width / 2;

			if (touch.position.x < middleX && (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)) {
				MoveLeft ();
			} else if (touch.position.x > middleX && (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)) {
				MoveRight ();
			} 
		} else {
			SetVelocityZero ();
		}
	}

	void MoveOnAcclerometer(){
		float accleratoInput = Input.acceleration.x;
		print (accleratoInput);
		if (accleratoInput < -0.1f) {
			MoveLeft ();
		} else if (accleratoInput > 0.1f) {
			MoveRight ();
		} else {
			SetVelocityZero ();
		}

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
