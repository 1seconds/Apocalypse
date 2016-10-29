using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	enum EnemyDirection {DIR_LEFT, DIR_UP, DIR_RIGHT, DIR_DOWN};

	private EnemyDirection curDirection;

	float moveDuration = 0.3f;
	private Vector2 curPlayerPos;

	void Start () {
		curDirection = EnemyDirection.DIR_UP;
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Move (EnemyDirection.DIR_LEFT);
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Move (EnemyDirection.DIR_RIGHT);
		}

		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			Move (EnemyDirection.DIR_UP);
		}

		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			Move (EnemyDirection.DIR_DOWN);
		}
	}
	
	void Move(EnemyDirection dir)
	{
		if (LeanTween.isTweening(this.gameObject)) return;

		switch (dir) {
		case EnemyDirection.DIR_UP:
			LeanTween.moveLocalY(this.gameObject, this.transform.position.y + 0.853333f, moveDuration).setOnComplete(UpdateEnemyState);
			this.curPlayerPos.x -= 1;
			break;
		case EnemyDirection.DIR_DOWN:
			LeanTween.moveLocalY(this.gameObject, this.transform.position.y - 0.853333f, moveDuration).setOnComplete(UpdateEnemyState);
			this.curPlayerPos.x += 1;
			break;
		case EnemyDirection.DIR_LEFT:
			LeanTween.moveLocalX(this.gameObject, this.transform.position.x - 0.853333f, moveDuration).setOnComplete(UpdateEnemyState);
			this.curPlayerPos.y -= 1;
			break;
		case EnemyDirection.DIR_RIGHT:
			LeanTween.moveLocalX(this.gameObject, this.transform.position.x + 0.853333f, moveDuration).setOnComplete(UpdateEnemyState);
			this.curPlayerPos.y += 1;
			break;
		}
	}

	void UpdateEnemyState()
	{
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			Debug.Log ("Enemy collided with Player");
		}
	}
}
