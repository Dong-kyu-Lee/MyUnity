using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanjaScript : MonoBehaviour
{
    [SerializeField]
    private int Count;
    public int FloorCount
    {
        set
        {
            Count = value;
            float MoveSize = Count * -0.5f;

            for(int i = 0; i < Count; i++)
            {
                GameObject NewObj = new GameObject("Floor");

                NewObj.transform.SetParent(transform);
                NewObj.transform.localPosition = new Vector3(i+ MoveSize, 0, 0);
                SpriteRenderer SR = NewObj.AddComponent<SpriteRenderer>();
                SR.sprite = LogicValue.MainFloorSprite;

                //코인 생성
                GameObject NewCoin = GameObject.Instantiate(LogicValue.CoinPrefab);
                NewCoin.transform.position = NewObj.transform.position + Vector3.up;
            }
            //Left Floor
            GameObject Left = new GameObject("LeftFloor");
            Left.transform.SetParent(transform);
            Left.transform.localPosition = new Vector3(-1.0f + MoveSize, 0, 0);
            SpriteRenderer LeftSR = Left.AddComponent<SpriteRenderer>();
            LeftSR.sprite = LogicValue.LeftFloorSprite;
            //Right Floor
            GameObject Right = new GameObject("RightFloor");
            Right.transform.SetParent(transform);
            Right.transform.localPosition = new Vector3(Count + MoveSize, 0, 0);
            SpriteRenderer RightSR = Right.AddComponent<SpriteRenderer>();
            RightSR.sprite = LogicValue.RightFloorSprite;
        }

        get
        {
            return Count;
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        // 코인 프리펩이 생성되지 않으면 에러 발생
        if (LogicValue.CoinPrefab == null)
        {
            Debug.LogError("LogicValue.CoinPrefab == null");
            Destroy(gameObject);
            return;
        }                                
    }

    // Update is called once per frame
    void Update()
    {

        if(Player.PlayerPos.x - transform.position.x >= 10.0f)
        {
            Destroy(gameObject);
        }
    }
    private void LateUpdate()
    {
        if (Player.IsDeath == true)
        {
            Destroy(gameObject);
        }
    }
}
