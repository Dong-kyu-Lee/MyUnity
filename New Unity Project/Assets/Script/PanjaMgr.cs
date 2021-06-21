using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanjaMgr : MonoBehaviour
{
    [SerializeField]
    Sprite mySprite = null;

    [SerializeField]
    private float CreateRandomRangeYStart = -2.0f;
    [SerializeField]
    private float CreateRandomRangeYEnd = 2.0f;

    [SerializeField]
    private float CreateRandomScaleXStart = 5.0f;
    [SerializeField]
    private float CreateRandomScaleXEnd = 10.0f;

    [SerializeField]
    private float CreateRandomInterXStart = 2.0f;
    [SerializeField]
    private float CreateRandomInterXEnd = 4.0f;

    [SerializeField]
    private float CreateRange = 20.0f;
    // ���������� ������� ������ ��ġ
    [SerializeField]
    private float LastCreatePosX = 0.0f;
    // ���������� ������� ������ ũ��
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
        // ���� ���� ��ġ ����
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

        // �� ���� ������Ʈ ����
        GameObject newPanja = new GameObject("Panja");
        //������ ũ�� ���ϱ�
        newPanja.transform.localScale = new Vector3(Random.Range(CreateRandomScaleXStart, CreateRandomScaleXEnd), 1.0f, 1.0f);
        Vector3 CreatePos = new Vector3();
        
        CreatePos.x = LastCreatePosX + LastCreateScaleX + newPanja.transform.localScale.x * 0.5f;
        CreatePos.x += Random.Range(CreateRandomInterXStart, CreateRandomInterXEnd);
        CreatePos.z = 0.0f;
        CreatePos.y = Random.Range(CreateRandomRangeYStart, CreateRandomRangeYEnd);
        newPanja.transform.position = CreatePos;


        SpriteRenderer NewSp = newPanja.AddComponent<SpriteRenderer>();
        NewSp.sprite = mySprite;
        NewSp.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);

        newPanja.AddComponent<BoxCollider>();
        newPanja.AddComponent<PanjaScript>();

        // ����
        LastCreatePosX = CreatePos.x;
        LastCreateScaleX = (newPanja.transform.localScale.x * 0.5f);

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
