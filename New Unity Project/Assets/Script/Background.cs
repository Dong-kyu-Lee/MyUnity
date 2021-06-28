using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private float Inter;
    [SerializeField]
    int Sort = 0;
    // Start is called before the first frame update
    void Awake()
    {
        SpriteRenderer SR = GetComponent<SpriteRenderer>();
        SR.sortingOrder = Sort;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
