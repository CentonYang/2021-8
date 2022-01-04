using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLP : MonoBehaviour
{
    public Transform[] 雷達光點;
    GameObject[] 光點;
    int 索引;
    Color 光色;
    void Start()
    {
        雷達光點 = GetComponentsInChildren<Transform>();
        光點 = GameObject.FindGameObjectsWithTag("Spot");
    }
    void Update()
    {
        for (索引 = 0; 索引 <= (雷達光點.Length - 2); 索引++)
        {
            雷達光點[索引 + 1].position =
            NPC.副本.非玩家角色[索引].transform.position;
        }
        foreach (var 非玩家角色 in 光點)
        {
            非玩家角色.GetComponent<Renderer>().material.color =
            NPC.副本.非玩家角色[0].
            GetComponent<Renderer>().material.color;
        }
    }
}
