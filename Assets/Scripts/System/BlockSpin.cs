﻿using UnityEngine;
using System;
using System.Collections;


public class BlockSpin : MonoBehaviour
{
    private Sprite[] block = new Sprite[4];
    private bool isenterCoroutine = false;
    [HideInInspector] public int randomNum;      //블럭 난수
    [HideInInspector] public int randomNum2;     //블럭 회전값 난수

    BlockManager blockmanager;

    void Awake()
    {
        //난수 생성
        randomNum = UnityEngine.Random.Range(0, 4);
        randomNum2 = UnityEngine.Random.Range(0, 4);
    }

    void Start()
    {
        blockmanager = Camera.main.gameObject.GetComponent<BlockManager>();
        
        for (int i =0; i<block.Length;i++)
        {
            block[i] = Camera.main.gameObject.GetComponent<BlockCollection>().block[i];
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = Camera.main.gameObject.GetComponent<BlockCollection>().block[randomNum];
        gameObject.transform.eulerAngles = new Vector3(0, 0, 90 * randomNum2);
    }

    void OnMouseUp()
    {
        Debug.Log(blockmanager.currentBlockNum);
        Debug.Log(Convert.ToInt32(gameObject.name));

        if(Convert.ToInt32(gameObject.name) + 12 != blockmanager.currentBlockNum)
        {
            if (!isenterCoroutine)
                StartCoroutine(StartSpin());
        }

        else
            blockmanager.DoNotSpin();
    }
    
    //회전
    IEnumerator StartSpin()
    {
        isenterCoroutine = true;
        blockmanager.TransformSpin(Convert.ToInt32(gameObject.name) - 1);

        for (int i = 0; i<30;i++)
        {
            gameObject.transform.eulerAngles += new Vector3(0, 0, 3);
            yield return new WaitForEndOfFrame();
        }

        blockmanager.DebugLog(Convert.ToInt32(gameObject.name) - 1);
        isenterCoroutine = false;
        //변환
    }
}