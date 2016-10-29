using UnityEngine;
using System.Collections;
using System;
using BridgeEnum;

[System.Serializable]
public class Object
{
    public GameObject block;
    public int[,] localMapFrame = new int[3, 3];
}

public class BlockManager : MonoBehaviour
{
    public Object[] blockInfo = new Object[32];
    static public int[,] mapFrame = new int[14, 26];    //12 x 24 (4 x 8) => 
    public Vector2 playerPos = new Vector2(0, 0);
    public int xtemp = 1;
    public int ytemp = 1;
    public int n = 0;
    public int currentBlockNum;

	public EnemyManager enemyManager;

    void Start()
    {
		enemyManager = GameObject.Find ("EnemyManager").GetComponent<EnemyManager> ();

        for (int i = 0; i < blockInfo.Length; i++)
        {
            blockInfo[i].block = gameObject.GetComponent<BlockCollection>().blockNum[i];      //해당 블럭
        }

        for (int i = 0; i < blockInfo.Length; i++)
        {
            // case 1
            if (gameObject.GetComponent<BlockCollection>().blockNum[i].GetComponent<BlockSpin>().randomNum == 0)
            {
                //case 1-1
                if (gameObject.GetComponent<BlockCollection>().blockNum[i].GetComponent<BlockSpin>().randomNum2 == 0 || gameObject.GetComponent<BlockCollection>().blockNum[i].GetComponent<BlockSpin>().randomNum2 == 2)
                {
                    blockInfo[i].localMapFrame[0, 0] = 0;
                    blockInfo[i].localMapFrame[0, 1] = 1;
                    blockInfo[i].localMapFrame[0, 2] = 0;
                    blockInfo[i].localMapFrame[1, 0] = 0;
                    blockInfo[i].localMapFrame[1, 1] = 1;
                    blockInfo[i].localMapFrame[1, 2] = 0;
                    blockInfo[i].localMapFrame[2, 0] = 0;
                    blockInfo[i].localMapFrame[2, 1] = 1;
                    blockInfo[i].localMapFrame[2, 2] = 0;
                }

                //case 1-2
                if (gameObject.GetComponent<BlockCollection>().blockNum[i].GetComponent<BlockSpin>().randomNum2 == 1 || gameObject.GetComponent<BlockCollection>().blockNum[i].GetComponent<BlockSpin>().randomNum2 == 3)
                {
                    blockInfo[i].localMapFrame[0, 0] = 0;
                    blockInfo[i].localMapFrame[0, 1] = 0;
                    blockInfo[i].localMapFrame[0, 2] = 0;
                    blockInfo[i].localMapFrame[1, 0] = 1;
                    blockInfo[i].localMapFrame[1, 1] = 1;
                    blockInfo[i].localMapFrame[1, 2] = 1;
                    blockInfo[i].localMapFrame[2, 0] = 0;
                    blockInfo[i].localMapFrame[2, 1] = 0;
                    blockInfo[i].localMapFrame[2, 2] = 0;
                }
            }

            // case 2
            if (gameObject.GetComponent<BlockCollection>().blockNum[i].GetComponent<BlockSpin>().randomNum == 1)
            {
                //case 2-1
                blockInfo[i].localMapFrame[0, 0] = 0;
                blockInfo[i].localMapFrame[0, 1] = 1;
                blockInfo[i].localMapFrame[0, 2] = 0;
                blockInfo[i].localMapFrame[1, 0] = 1;
                blockInfo[i].localMapFrame[1, 1] = 1;
                blockInfo[i].localMapFrame[1, 2] = 1;
                blockInfo[i].localMapFrame[2, 0] = 0;
                blockInfo[i].localMapFrame[2, 1] = 1;
                blockInfo[i].localMapFrame[2, 2] = 0;
            }

            // case 3
            if (gameObject.GetComponent<BlockCollection>().blockNum[i].GetComponent<BlockSpin>().randomNum == 2)
            {
                //case 3-1
                if (gameObject.GetComponent<BlockCollection>().blockNum[i].GetComponent<BlockSpin>().randomNum2 == 0)
                {
                    blockInfo[i].localMapFrame[0, 0] = 0;
                    blockInfo[i].localMapFrame[0, 1] = 1;
                    blockInfo[i].localMapFrame[0, 2] = 0;
                    blockInfo[i].localMapFrame[1, 0] = 1;
                    blockInfo[i].localMapFrame[1, 1] = 1;
                    blockInfo[i].localMapFrame[1, 2] = 0;
                    blockInfo[i].localMapFrame[2, 0] = 0;
                    blockInfo[i].localMapFrame[2, 1] = 0;
                    blockInfo[i].localMapFrame[2, 2] = 0;
                }

                //case 3-2
                if (gameObject.GetComponent<BlockCollection>().blockNum[i].GetComponent<BlockSpin>().randomNum2 == 1)
                {
                    blockInfo[i].localMapFrame[0, 0] = 0;
                    blockInfo[i].localMapFrame[0, 1] = 0;
                    blockInfo[i].localMapFrame[0, 2] = 0;
                    blockInfo[i].localMapFrame[1, 0] = 1;
                    blockInfo[i].localMapFrame[1, 1] = 1;
                    blockInfo[i].localMapFrame[1, 2] = 0;
                    blockInfo[i].localMapFrame[2, 0] = 0;
                    blockInfo[i].localMapFrame[2, 1] = 1;
                    blockInfo[i].localMapFrame[2, 2] = 0;

                }

                //case 3-3
                if (gameObject.GetComponent<BlockCollection>().blockNum[i].GetComponent<BlockSpin>().randomNum2 == 2)
                {
                    blockInfo[i].localMapFrame[0, 0] = 0;
                    blockInfo[i].localMapFrame[0, 1] = 0;
                    blockInfo[i].localMapFrame[0, 2] = 0;
                    blockInfo[i].localMapFrame[1, 0] = 0;
                    blockInfo[i].localMapFrame[1, 1] = 1;
                    blockInfo[i].localMapFrame[1, 2] = 1;
                    blockInfo[i].localMapFrame[2, 0] = 0;
                    blockInfo[i].localMapFrame[2, 1] = 1;
                    blockInfo[i].localMapFrame[2, 2] = 0;
                }

                //case 3-4
                if (gameObject.GetComponent<BlockCollection>().blockNum[i].GetComponent<BlockSpin>().randomNum2 == 3)
                {
                    blockInfo[i].localMapFrame[0, 0] = 0;
                    blockInfo[i].localMapFrame[0, 1] = 1;
                    blockInfo[i].localMapFrame[0, 2] = 0;
                    blockInfo[i].localMapFrame[1, 0] = 0;
                    blockInfo[i].localMapFrame[1, 1] = 1;
                    blockInfo[i].localMapFrame[1, 2] = 1;
                    blockInfo[i].localMapFrame[2, 0] = 0;
                    blockInfo[i].localMapFrame[2, 1] = 0;
                    blockInfo[i].localMapFrame[2, 2] = 0;
                }
            }

            // case 4
            if (gameObject.GetComponent<BlockCollection>().blockNum[i].GetComponent<BlockSpin>().randomNum == 3)
            {
                //case 4-1
                if (gameObject.GetComponent<BlockCollection>().blockNum[i].GetComponent<BlockSpin>().randomNum2 == 0)
                {
                    blockInfo[i].localMapFrame[0, 0] = 0;
                    blockInfo[i].localMapFrame[0, 1] = 1;
                    blockInfo[i].localMapFrame[0, 2] = 0;
                    blockInfo[i].localMapFrame[1, 0] = 1;
                    blockInfo[i].localMapFrame[1, 1] = 1;
                    blockInfo[i].localMapFrame[1, 2] = 1;
                    blockInfo[i].localMapFrame[2, 0] = 0;
                    blockInfo[i].localMapFrame[2, 1] = 0;
                    blockInfo[i].localMapFrame[2, 2] = 0;
                }

                //case 4-2
                if (gameObject.GetComponent<BlockCollection>().blockNum[i].GetComponent<BlockSpin>().randomNum2 == 1)
                {
                    blockInfo[i].localMapFrame[0, 0] = 0;
                    blockInfo[i].localMapFrame[0, 1] = 1;
                    blockInfo[i].localMapFrame[0, 2] = 0;
                    blockInfo[i].localMapFrame[1, 0] = 1;
                    blockInfo[i].localMapFrame[1, 1] = 1;
                    blockInfo[i].localMapFrame[1, 2] = 0;
                    blockInfo[i].localMapFrame[2, 0] = 0;
                    blockInfo[i].localMapFrame[2, 1] = 1;
                    blockInfo[i].localMapFrame[2, 2] = 0;
                }

                //case 4-3
                if (gameObject.GetComponent<BlockCollection>().blockNum[i].GetComponent<BlockSpin>().randomNum2 == 2)
                {
                    blockInfo[i].localMapFrame[0, 0] = 0;
                    blockInfo[i].localMapFrame[0, 1] = 0;
                    blockInfo[i].localMapFrame[0, 2] = 0;
                    blockInfo[i].localMapFrame[1, 0] = 1;
                    blockInfo[i].localMapFrame[1, 1] = 1;
                    blockInfo[i].localMapFrame[1, 2] = 1;
                    blockInfo[i].localMapFrame[2, 0] = 0;
                    blockInfo[i].localMapFrame[2, 1] = 1;
                    blockInfo[i].localMapFrame[2, 2] = 0;
                }

                //case 4-4
                if (gameObject.GetComponent<BlockCollection>().blockNum[i].GetComponent<BlockSpin>().randomNum2 == 3)
                {
                    blockInfo[i].localMapFrame[0, 0] = 0;
                    blockInfo[i].localMapFrame[0, 1] = 1;
                    blockInfo[i].localMapFrame[0, 2] = 0;
                    blockInfo[i].localMapFrame[1, 0] = 0;
                    blockInfo[i].localMapFrame[1, 1] = 1;
                    blockInfo[i].localMapFrame[1, 2] = 1;
                    blockInfo[i].localMapFrame[2, 0] = 0;
                    blockInfo[i].localMapFrame[2, 1] = 1;
                    blockInfo[i].localMapFrame[2, 2] = 0;
                }
            }
            UpdateFrameState(i);
        }
    }

    public void CurrentBlock(int x, int y)
    {
        xtemp += x;
        ytemp += y;

        // 오른쪽으로 이동
        if(xtemp > 2)
        {
            currentBlockNum += 1;
            xtemp = 0;
        }
            

        //왼쪽으로 이동
        if(xtemp < 0)
        {
            currentBlockNum -= 1;
            xtemp = 2;
        }
            

        //위쪽으로 이동
        if(ytemp > 2)
        {
            currentBlockNum -= 10;
            ytemp = 0;
            n += 1;
        }
            

        //아래쪽으로이동
        if(ytemp < 0)
        {
            currentBlockNum += 10;
            ytemp = 2;
            n -= 1;
        }
            
    }

    public void UpdateFrameState(int i)
    {
        int j = (i / 8) + 1;      //행 
        int k = (i % 8) + 1;      //열

        mapFrame[1 + (j - 1) * 3, 1 + (k - 1) * 3] = blockInfo[i].localMapFrame[0, 0];
        mapFrame[1 + (j - 1) * 3, 1 + (k - 1) * 3 + 1] = blockInfo[i].localMapFrame[0, 1];
        mapFrame[1 + (j - 1) * 3, 1 + (k - 1) * 3 + 2] = blockInfo[i].localMapFrame[0, 2];
        mapFrame[1 + (j - 1) * 3 + 1, 1 + (k - 1) * 3] = blockInfo[i].localMapFrame[1, 0];
        mapFrame[1 + (j - 1) * 3 + 1, 1 + (k - 1) * 3 + 1] = blockInfo[i].localMapFrame[1, 1];
        mapFrame[1 + (j - 1) * 3 + 1, 1 + (k - 1) * 3 + 2] = blockInfo[i].localMapFrame[1, 2];
        mapFrame[1 + (j - 1) * 3 + 2, 1 + (k - 1) * 3] = blockInfo[i].localMapFrame[2, 0];
        mapFrame[1 + (j - 1) * 3 + 2, 1 + (k - 1) * 3 + 1] = blockInfo[i].localMapFrame[2, 1];
        mapFrame[1 + (j - 1) * 3 + 2, 1 + (k - 1) * 3 + 2] = blockInfo[i].localMapFrame[2, 2];
    }

    public void DoNotSpin()
    {
        return;
    }

    public void TransformSpin(int i)
    {
        int temp = blockInfo[i].localMapFrame[1, 0];

        blockInfo[i].localMapFrame[1, 0] = blockInfo[i].localMapFrame[0, 1];
        blockInfo[i].localMapFrame[0, 1] = blockInfo[i].localMapFrame[1, 2];
        blockInfo[i].localMapFrame[1, 2] = blockInfo[i].localMapFrame[2, 1];
        blockInfo[i].localMapFrame[2, 1] = temp;

        UpdateFrameState(i);
    }

    public void DebugLog(int i)
    {
        Debug.Log(blockInfo[i].localMapFrame[0, 0] + " " + blockInfo[i].localMapFrame[0, 1] + " " + blockInfo[i].localMapFrame[0, 2]);
        Debug.Log(blockInfo[i].localMapFrame[1, 0] + " " + blockInfo[i].localMapFrame[1, 1] + " " + blockInfo[i].localMapFrame[1, 2]);
        Debug.Log(blockInfo[i].localMapFrame[2, 0] + " " + blockInfo[i].localMapFrame[2, 1] + " " + blockInfo[i].localMapFrame[2, 2]);
    }

    public bool IsPlayerMovable(int dir)
    {
        switch (dir) {
            //Left
            case 0:
                if (mapFrame[(int)playerPos.x, (int)playerPos.y - 1] == 0)
                    return false;
                break;
            //Up
            case 1:
                if (mapFrame[(int)playerPos.x - 1, (int)playerPos.y] == 0)
                    return false;
                break;
            //Right
            case 2:
                if (mapFrame[(int)playerPos.x, (int)playerPos.y + 1] == 0)
                    return false;
                break;
            //Down
            case 3:
                if (mapFrame[(int)playerPos.x + 1, (int)playerPos.y] == 0)
                    return false;
                break;
        }
        return true;
    }

	public bool IsEnemyMovable(Enemy enemy, Direction dir)
	{
		switch (dir) {
		//Left
		case Direction.DIR_LEFT:
			if (mapFrame[(int)enemy.curPos.x, (int)enemy.curPos.y - 1] == 0)
				return false;
			break;
			//Up
		case Direction.DIR_UP:
			if (mapFrame[(int)enemy.curPos.x - 1, (int)enemy.curPos.y] == 0)
				return false;
			break;
			//Right
		case Direction.DIR_RIGHT:
			if (mapFrame[(int)enemy.curPos.x, (int)enemy.curPos.y + 1] == 0)
				return false;
			break;
			//Down
		case Direction.DIR_DOWN:
			if (mapFrame[(int)enemy.curPos.x + 1, (int)enemy.curPos.y] == 0)
				return false;
			break;
		}
		return true;
	}

	public bool IsEnemyOnTheBlock(int blockIndex)
	{
		for (int i = 0; i < enemyManager.enemies.Count; i++) {
			int x = ((int)enemyManager.enemies [i].curPos.x-1) / 3;
			int y = ((int)enemyManager.enemies [i].curPos.y-1) / 3;


			int enemyBlockIndex = x * 8 + y;

			if (blockIndex == enemyBlockIndex)
				return true;
		}

		return false;
	}
}
