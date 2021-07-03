using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Text나 Botton같은 UGUI의 컴포넌트를 사용할 수 있다.
using UnityEngine.UI;
//Ipointer 이벤트 등록
using UnityEngine.EventSystems;
//Scene 넘기는 일
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene("Play"); // Scene 로드
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
