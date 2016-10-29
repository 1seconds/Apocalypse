using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {

	public GameObject enemyPrefab;
	public List<Enemy> enemies = new List<Enemy> ();
	public int enemyCount = 3;

	// Use this for initialization
	void Start () {
		GenerateEnemies ();
	}

	void GenerateEnemies()
	{
		for (int i = 0; i < enemyCount; i++) {
			GameObject o = Instantiate (enemyPrefab) as GameObject;
            enemyPrefab.tag = "Enemy";

            int randX = Random.Range (0, 4)*3 + 2;
			int randY = Random.Range (4, 8)*3 + 2;

			o.GetComponent<Enemy> ().Init (randX, randY);
			enemies.Add (o.GetComponent<Enemy> ());
		}
	}
}
