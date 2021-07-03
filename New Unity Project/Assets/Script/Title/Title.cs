using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField]
    private float deathLen;

    [SerializeField]
    private float createLen;

    [SerializeField]
    private float createInter;

    [SerializeField]
    private int Order;

    private bool m_isCreate = false;
    private float speed = 10.0f;

    void Awake()
    {
        SpriteRenderer SR = GetComponent<SpriteRenderer>();

        if(null == SR)
        {
            Debug.LogError("Title  is Null");
        }
        SR.sortingOrder = Order;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;

        /*if(transform.position.x < deathLen)
        {
            transform.position = new Vector3(8.0f, -0.5f, -5.0f);
        }*/
        if (m_isCreate == false && createLen > transform.position.x)
        {
            GameObject Obj = LogicValue.NameInst(gameObject);
            Obj.transform.position += (Vector3.right * createInter);
            m_isCreate = true;
        }

        if (deathLen > (transform.position.x))
        {
            Destroy(gameObject);
        }
    }
}
