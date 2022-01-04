using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCTarget : MonoBehaviour
{
    public Transform[] 反追器;
    public static Vector3 位置;
    public GameObject 目標;
    GameObject 玩家;
    int 索引;
    float 距離;
    void Start()
    {
        玩家 = GameObject.FindGameObjectWithTag("Player");
        索引 = 0;
        位置 = 反追器[索引].position;
        Instantiate(目標, 位置, transform.localRotation);
    }
    void Update()
    {
        距離 = Vector3.Distance(玩家.transform.position, 位置);
        位置 = 反追器[索引].position;
        目標 = GameObject.FindGameObjectWithTag("Target");
        目標.transform.Rotate(0, 1.5f, 0);
        if (距離 < 1.5)
        {
            索引 = (索引 + 1) % 反追器.Length;
        }
    }
}
