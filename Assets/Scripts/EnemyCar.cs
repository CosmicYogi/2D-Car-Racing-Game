using UnityEngine;
using System.Collections;

public class EnemyCar : MonoBehaviour {


	public float speed = 5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector2 (0, speed * Time.deltaTime));
	}
}
