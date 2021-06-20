using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.right * Time.deltaTime * LogicValue.MoveSpeed;
    }
}
