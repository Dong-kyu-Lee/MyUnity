using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigid = null;

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
    }

    private bool isJump = false;
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * LogicValue.MoveSpeed;
        m_PlayerPos = transform.position;

        if(Input.GetKeyDown(KeyCode.Space) && isJump == false)
        {
            rigid.AddForce(Vector3.up * LogicValue.JumpPower,ForceMode.Impulse);
            isJump = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJump = false;
    }
}
