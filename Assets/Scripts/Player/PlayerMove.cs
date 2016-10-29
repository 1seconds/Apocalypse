using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    float moveDuration = 0.3f;
    private Vector2 curPlayerPos;
    BlockManager blockManager;

    void Start()
    {
        blockManager = Camera.main.gameObject.GetComponent<BlockManager>();
        curPlayerPos = new Vector2(5, 2);
        UpdatePlayerState();
    }

    void MoveUp()
    {
        if (LeanTween.isTweening(this.gameObject)) return;
        
        if (blockManager.IsPlayerMovable(1))
        {
            LeanTween.moveLocalY(this.gameObject, this.transform.position.y + 0.853333f, moveDuration).setOnComplete(UpdatePlayerState);
            this.curPlayerPos.x -= 1;
            blockManager.CurrentBlock(0,1);
        }
    }

    void MoveDown()
    {
        if (LeanTween.isTweening(this.gameObject)) return;

        
        if (blockManager.IsPlayerMovable(3))
        {
            LeanTween.moveLocalY(this.gameObject, this.transform.position.y - 0.853333f, moveDuration).setOnComplete(UpdatePlayerState);
            this.curPlayerPos.x += 1;
            blockManager.CurrentBlock(0, -1);
        }
    }

    void MoveLeft()
    {
        if (LeanTween.isTweening(this.gameObject)) return;
        
        if(blockManager.IsPlayerMovable(0))
        {
            LeanTween.moveLocalX(this.gameObject, this.transform.position.x - 0.853333f, moveDuration).setOnComplete(UpdatePlayerState);
            this.curPlayerPos.y -= 1;
            blockManager.CurrentBlock(-1, 0);
        }
    }

    void MoveRight()
    {
        if (LeanTween.isTweening(this.gameObject)) return;
        
        if (blockManager.IsPlayerMovable(2))
        {
            LeanTween.moveLocalX(this.gameObject, this.transform.position.x + 0.853333f, moveDuration).setOnComplete(UpdatePlayerState);
            this.curPlayerPos.y += 1;
            blockManager.CurrentBlock(1, 0);
        }
    }

    void UpdatePlayerState()
    {
        blockManager.playerPos = this.curPlayerPos;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            MoveDown();
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            MoveUp();
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            MoveLeft();
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            MoveRight();
    }
}
