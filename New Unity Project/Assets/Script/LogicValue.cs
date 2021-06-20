using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//데이터 직렬화를 자동으로 해줌
//컴퓨터가 일고 쓰기 쉽게 변경해줌
[Serializable]
public class CameraAndPlayerData
{
    [SerializeField]
    public float m_MoveSpeed = 10.0f;
    [SerializeField]
    public float m_JumpPower = 20.0f;
}

public class LogicValue : MonoBehaviour
{
    // 많이 변경될 것 같은 게임 내의 값들을 모아놓자
    private static LogicValue Inst = null;

    [SerializeField]
    CameraAndPlayerData m_CameraAndPlayerData = new CameraAndPlayerData();
    public static float MoveSpeed
    {
        get
        {
            return Inst.m_CameraAndPlayerData.m_MoveSpeed;
        }
    }

    public static float JumpPower
    {
        get
        {
            return Inst.m_CameraAndPlayerData.m_JumpPower;
        }
    }

    private void Awake()
    {
        Inst = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
