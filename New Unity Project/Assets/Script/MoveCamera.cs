using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private static Vector3 StartPos = Vector3.zero;
    private static MoveCamera GameCamera = null;
    public static Camera CamCom;
    public static void CameraReset()
    {
        GameCamera.transform.position = StartPos;
    }

    private void Awake()
    {
        CamCom = GetComponent<Camera>();
        StartPos = transform.position;
        GameCamera = this;
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.right * Time.deltaTime * LogicValue.MoveSpeed;
    }
}
