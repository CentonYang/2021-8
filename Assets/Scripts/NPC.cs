using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPC: MonoBehaviour {
public List<NavMeshAgent> 非玩家角色 = new List<NavMeshAgent>();
GameObject 玩家;
Transform[] 起始物件;
public Vector3[] 起始座標;
int 索引;
public static bool 逃離;
public static float 開始逃離;
public int 逃離秒數;
public static NPC 副本;
public static bool 歸位;
void Start()
{
    玩家 = GameObject.FindGameObjectWithTag("Player");
    副本 = this;
    逃離 = false;
    起始物件 = GetComponentsInChildren<Transform>();
    for (索引 = 0; 索引 <= (起始座標.Length - 1); 索引++)
    {
        起始座標[索引] = 起始物件[索引 + 1].position;
    }
    追捕();
}
void 追捕()
{
    foreach (var 追擊者 in 非玩家角色)
    {
        追擊者.SetDestination(玩家.transform.position);
        追擊者.GetComponent<Renderer>().material.color = Color.red;
    }
}

void 躲開()
{
    float 距離;

    if (Time.time - 開始逃離 > 逃離秒數)
    {
        逃離 = !逃離;
    }
    for (索引 = 0; 索引 <= (非玩家角色.Count - 1); 索引++)
    {
        非玩家角色[索引].SetDestination(起始座標[索引]);
        距離 = Vector3.Distance(玩家.transform.position,
        非玩家角色[索引].transform.position);
        if (距離 < 1.0f)
        {
            非玩家角色[索引].transform.position = 起始座標[索引];
            歸位 = true;
        }
    }

    foreach (var 逃離者 in 非玩家角色)
    {
        逃離者.GetComponent<Renderer>().material.color = Color.blue;
    }
}
void Update()
{
    if (!逃離)
    {
        追捕();
    }
    else
    {
        逃離 = true;
        歸位 = false;
        躲開();
    }
}
}
