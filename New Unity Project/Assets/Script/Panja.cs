using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panja : MonoBehaviour
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

    // Start is called before the first frame update

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

        newPanja.AddComponent<BoxCollider>();

        // ����
        LastCreatePosX = CreatePos.x;
        LastCreateScaleX = (newPanja.transform.localScale.x * 0.5f);

        return true;
    }

    void CheckPanjaCreate()
    {
        while (NewPanjaLogic());
    }

    private void Awake()
    {
        CheckPanjaCreate();
    }

    // Update is called once per frame
    void Update()
    {
        NewPanjaLogic();
    }
}
