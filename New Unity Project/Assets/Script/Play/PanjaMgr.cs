using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanjaMgr : MonoBehaviour
{
    [SerializeField]
    private float CreateRandomRangeYStart = -2.0f;
    [SerializeField]
    private float CreateRandomRangeYEnd = 2.0f;

    [SerializeField]
    private int CreateRandomScaleXStart = 5;
    [SerializeField]
    private int CreateRandomScaleXEnd = 10;

    [SerializeField]
    private float CreateRandomInterXStart = 2.0f;
    [SerializeField]
    private float CreateRandomInterXEnd = 4.0f;

    [SerializeField]
    private float CreateRange = 20.0f;
    // 마지막으로 만들어진 판자의 위치
    [SerializeField]
    private float LastCreatePosX = 0.0f;
    // 마지막으로 만들어진 판자의 크기
    [SerializeField]
    private float LastCreateScaleX = 0.0f;

    private float ResetLastCreatePosX = 0.0f;
    private float ResetLastCreateScaleX = 0.0f;

    public static PanjaMgr MainPanjaMgr;
    public static void PanjaReset()
    {
        MainPanjaMgr.ResetData();
    }

    // Start is called before the first frame update
    private void Awake()
    {
        ResetLastCreatePosX = LastCreatePosX;
        ResetLastCreateScaleX = LastCreateScaleX;
        MainPanjaMgr = this;
        CheckPanjaCreate();
    }

    public void ResetData()
    {
        // 판자 생성 위치 리셋
        LastCreatePosX = ResetLastCreatePosX;
        LastCreateScaleX = ResetLastCreateScaleX;
        CheckPanjaCreate();
    }

    bool NewPanjaLogic()
    {
        if(LastCreatePosX >= Player.PlayerPos.x + CreateRange)
        {
            return false;
        }
        int NewFloorCount = Random.Range(CreateRandomScaleXStart, CreateRandomScaleXEnd + 1);

        // 새 게임 오브젝트 생성
        GameObject newPanja = new GameObject("Panja");
        //판자의 크기 정하기
        //newPanja.transform.localScale = new Vector3(Random.Range(CreateRandomScaleXStart, CreateRandomScaleXEnd), 1.0f, 1.0f);
        Vector3 CreatePos = new Vector3();
        
        CreatePos.x = LastCreatePosX + LastCreateScaleX + (NewFloorCount * 1.0f);
        CreatePos.x += Random.Range(CreateRandomInterXStart, CreateRandomInterXEnd);
        CreatePos.z = 0.0f;
        CreatePos.y = Random.Range(CreateRandomRangeYStart, CreateRandomRangeYEnd);
        newPanja.transform.position = CreatePos;


        /*SpriteRenderer NewSp = newPanja.AddComponent<SpriteRenderer>();
        NewSp.sprite = mySprite;
        NewSp.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);*/

        PanjaScript PS = newPanja.AddComponent<PanjaScript>();
        PS.FloorCount = NewFloorCount;

        BoxCollider BC = newPanja.AddComponent<BoxCollider>();
        BC.size = new Vector3(NewFloorCount+1, 1, 1);
        BC.center = new Vector3(-0.5f, 0, 0);

        // 갱신
        LastCreatePosX = CreatePos.x;
        LastCreateScaleX = (PS.FloorCount * 0.5f);

        //newPanja.AddComponent<BoxCollider>();
        //newPanja.AddComponent<PanjaScript>();
        return true;
    }

    void CheckPanjaCreate()
    {
        while (NewPanjaLogic());
    }
    
    void Update()
    {
        NewPanjaLogic();
    }
}
