using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ ����ȭ�� �ڵ����� ����
//��ǻ�Ͱ� �ϰ� ���� ���� ��������
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
    // ���� ����� �� ���� ���� ���� ������ ��Ƴ���
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
