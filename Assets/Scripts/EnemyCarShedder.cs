using UnityEngine;
using System.Collections;

public class EnemyCarShedder: MonoBehaviour {

	void OnCollisionEnter2D(Collision2D enemyCar){
		GameObject enemyCarCollided = enemyCar.gameObject as GameObject;
		if (enemyCarCollided.GetComponent<EnemyCar> ()) {
			Destroy (enemyCar.gameObject);
		}
	}
}
