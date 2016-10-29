using UnityEngine;
using System.Collections;
using BridgeEnum;

public class Enemy : MonoBehaviour {

	private Direction curDirection;

	float moveDuration = 0.3f;
	float moveCooltime = 1f;
	public Vector2 curPos;

	BlockManager blockManager;

	Sprite[] sprites = new Sprite[4];
	SpriteRenderer sr;

	public void Init(int x, int y)
	{
		curPos = new Vector2 (x, y);

		this.transform.position = new Vector2 (-6.95f + 0.55f * y, 4.05f - 0.55f * x);
	}

	void Start () {
		curDirection = Direction.DIR_UP;
		blockManager = Camera.main.gameObject.GetComponent<BlockManager>();

		sprites [0] = Resources.Load ("Images/Statue_left.png") as Sprite;
		sprites [1] = Resources.Load ("Images/Statue_back.png") as Sprite;
		sprites [2] = Resources.Load ("Images/Statue_right.png") as Sprite;
		sprites [3] = Resources.Load ("Images/Statue_front.png") as Sprite;

		sr = this.GetComponent<SpriteRenderer> ();
		sr.sprite = sprites [1];


		StartCoroutine ("MoveRoutine");
	}

	IEnumerator MoveRoutine()
	{

		while (true) {
			
			yield return new WaitForSeconds (moveCooltime);

			Direction leftward, rightward, backward;

			//null값 방지
			leftward = Direction.DIR_NONE;
			rightward = Direction.DIR_NONE;
			backward = Direction.DIR_NONE;

			//현재 방향에 따서 left, right, backward를 설정
			switch (curDirection) {
			case Direction.DIR_UP:
				leftward = Direction.DIR_LEFT;
				rightward = Direction.DIR_RIGHT;
				backward = Direction.DIR_DOWN;
				break;
			case Direction.DIR_LEFT:
				leftward = Direction.DIR_DOWN;
				rightward = Direction.DIR_UP;
				backward = Direction.DIR_RIGHT;
				break;
			case Direction.DIR_DOWN:
				leftward = Direction.DIR_RIGHT;
				rightward = Direction.DIR_LEFT;
				backward = Direction.DIR_UP;
				break;
			case Direction.DIR_RIGHT:
				leftward = Direction.DIR_UP;
				rightward = Direction.DIR_DOWN;
				backward = Direction.DIR_LEFT;
				break;
			}

			//forward가 막힐 경우.
			//다음방향을 leftward로 할지, rightward로 할지
			bool isLeftward = (Random.Range (0, 100) < 50) ? true : false;
			Direction secondBestDir, thirdBestDir = Direction.DIR_NONE;
			if (isLeftward) {
				secondBestDir = leftward;
				thirdBestDir = rightward;
			} else {
				secondBestDir = rightward;
				thirdBestDir = leftward;
			}

			if (blockManager.IsEnemyMovable (this, curDirection)) {
				Move (curDirection);

			} else if (blockManager.IsEnemyMovable (this, secondBestDir)) {
				Move (secondBestDir);
				curDirection = secondBestDir;
			} else if (blockManager.IsEnemyMovable (this, thirdBestDir)) {
				Move (thirdBestDir);
				curDirection = thirdBestDir;
			} else if(backward != Direction.DIR_NONE){
				Move (backward);
				curDirection = backward;
			}

			switch (curDirection) {
			case Direction.DIR_LEFT:
				sr.sprite = sprites [0];
				break;
			case Direction.DIR_UP:
				sr.sprite = sprites [1];
				break;
			case Direction.DIR_RIGHT:
				sr.sprite = sprites [2];
				break;
			case Direction.DIR_DOWN:
				sr.sprite = sprites [3];
				break;
			}
		}
	}

	void Move(Direction dir)
	{
		if (LeanTween.isTweening(this.gameObject)) return;

		switch (dir) {
		case Direction.DIR_UP:
			if (!blockManager.IsEnemyMovable (this, Direction.DIR_UP))
				return;

			LeanTween.moveLocalY(this.gameObject, this.transform.position.y + 0.55f, moveDuration).setOnComplete(UpdateEnemyState);
			this.curPos.x -= 1;
			break;
		case Direction.DIR_DOWN:
			if (!blockManager.IsEnemyMovable (this, Direction.DIR_DOWN))
				return;

			LeanTween.moveLocalY(this.gameObject, this.transform.position.y - 0.55f, moveDuration).setOnComplete(UpdateEnemyState);
			this.curPos.x += 1;
			break;
		case Direction.DIR_LEFT:
			if (!blockManager.IsEnemyMovable (this, Direction.DIR_LEFT))
				return;

			LeanTween.moveLocalX(this.gameObject, this.transform.position.x - 0.55f, moveDuration).setOnComplete(UpdateEnemyState);
			this.curPos.y -= 1;
			break;
		case Direction.DIR_RIGHT:
			if (!blockManager.IsEnemyMovable (this, Direction.DIR_RIGHT))
				return;

			LeanTween.moveLocalX(this.gameObject, this.transform.position.x + 0.55f, moveDuration).setOnComplete(UpdateEnemyState);
			this.curPos.y += 1;
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
