using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigid = null;

    private static bool m_isDeath;
    public static bool IsDeath
    {
        get
        {
            return m_isDeath;
        }
    }

    private int m_JumpCount;
    private static Vector3 m_PlayerPos;
    public static Vector3 PlayerPos
    {
        get
        {
            return m_PlayerPos;
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        Transform transform = GetComponent<Transform>();

        m_JumpCount = LogicValue.JumpCount;
    }

    private void FixedUpdate()
    {
        if (m_isDeath == true)
        {
            PanjaMgr.PanjaReset();
            m_isDeath = false;
        }
    }

    void Update()
    {
        //플레이어가 죽었을 때
        if(transform.position.y <= -MoveCamera.CamCom.orthographicSize)
        {
            transform.position = Vector3.zero;
            MoveCamera.CameraReset();
            m_isDeath = true;
        }

        transform.position += Vector3.right * Time.deltaTime * LogicValue.MoveSpeed;
        m_PlayerPos = transform.position;

        if(Input.GetKeyDown(KeyCode.Space) && m_JumpCount > 0)
        {
            rigid.velocity =  Vector3.zero;
            rigid.AddForce(Vector3.up * LogicValue.JumpPower,ForceMode.Impulse);
            --m_JumpCount;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_JumpCount = LogicValue.JumpCount;
    }
}
