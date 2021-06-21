using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void Update()
    {

        if (Player.PlayerPos.x - transform.position.x >= 10.0f)
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
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
