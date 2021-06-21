using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanjaScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        // ���� �������� �������� ������ ���� �߻�
        if (LogicValue.CoinPrefab == null)
        {
            Debug.LogError("LogicValue.CoinPrefab == null");
            Destroy(gameObject);
            return;
        }
        else
        {

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
