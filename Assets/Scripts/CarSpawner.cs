using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour {

	public GameObject[] carsToSpawn; 
	public float delayTimer = 1f;

	private float timer;
	private float maxPos = 2.5f;
	// Use this for initialization
	void Start () {
		timer = delayTimer;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Vector3 carSpawnPoint = new Vector3 (Random.Range (-maxPos, maxPos), transform.position.y, transform.position.z);
			Instantiate (carsToSpawn[Random.Range(0,carsToSpawn.Length)], carSpawnPoint, transform.rotation);
			timer = delayTimer;
		}
	}
}
