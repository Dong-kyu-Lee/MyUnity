using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Text�� Botton���� UGUI�� ������Ʈ�� ����� �� �ִ�.
using UnityEngine.UI;
//Ipointer �̺�Ʈ ���
using UnityEngine.EventSystems;
//Scene �ѱ�� ��
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene("Play"); // Scene �ε�
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
