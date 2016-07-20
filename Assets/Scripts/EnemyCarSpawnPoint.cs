using UnityEngine;
using System.Collections;

public class EnemyCarSpawnPoint : MonoBehaviour {

	public GameObject carToSpawn; 

	private float maxPos = 2.5f;
	// Use this for initialization
	void Start () {
		Vector3 carSpawnPoint = new Vector3 (Random.Range (-maxPos, maxPos),carToSpawn.transform.position.y, carToSpawn.transform.position.z);

		Instantiate (carToSpawn, carSpawnPoint, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
