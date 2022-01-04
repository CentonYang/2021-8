using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NPCR : MonoBehaviour
{
    private GameObject 玩家;
    private Vector3 初始座標;
    private Animator 呈現顏色;
    public float 追擊半徑;
    public float 遊走半徑;
    public float 警戒半徑;
    public float 自衛半徑;
    public float 攻擊範圍;
    public float 移動速度;
    public float 轉身速度;
    private enum NPC狀態
    { 觀察, 移動, 警戒, 追擊, 返回 }
    private NPC狀態 目前狀態 = NPC狀態.觀察;
    private float 威脅距離;
    private float 返回距離;
    private Quaternion 轉身方位;
    public float[] 變色權重 = { 100, 200 };
    public float 停頓秒數;
    float 指令時間;
    bool 防備;
    bool 跑步;
    public static bool 暫停;
    public GameObject 噴火;

    void Start()
    {
        暫停 = false;
        玩家 = GameObject.FindGameObjectWithTag("Player");
        呈現顏色 = GetComponent<Animator>();
        初始座標 = gameObject.GetComponent<Transform>().position;
        遊走半徑 = Mathf.Min(遊走半徑, 追擊半徑);
        自衛半徑 = Mathf.Min(自衛半徑, 警戒半徑);
        攻擊範圍 = Mathf.Min(攻擊範圍, 自衛半徑);
        隨機狀態();
    }
    void 隨機狀態()
    {
        指令時間 = Time.time;
        float number = Random.Range(0, 變色權重[0] + 變色權重[1]);
        if (number <= 變色權重[0])
        {
            目前狀態 = NPC狀態.觀察;
            呈現顏色.SetTrigger("觀察");
        }
        else if
        (變色權重[0] < number && number <= 變色權重[0] + 變色權重[1])
        {
            目前狀態 = NPC狀態.移動;
            轉身方位 = Quaternion.Euler(0, Random.Range(1, 5) * 90, 0);
            呈現顏色.SetTrigger("移動");
        }
    }
    void Update()
    {
        if (暫停 == false)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
        switch (目前狀態)
        {
            case NPC狀態 . 觀察:
                if (Time.time - 指令時間 > 停頓秒數)
                {
                    隨機狀態();
                }
                探查中();
                break;
            case NPC狀態 . 移動:
                transform.Translate(Vector3.forward * Time.deltaTime * 移動速度);
                transform.rotation = Quaternion.Slerp(transform.rotation, 轉身方位, 轉身速度);

                if (Time.time - 指令時間 > 停頓秒數)
                {

                    隨機狀態();
                }
                巡邏中();
                break;
            case NPC狀態 . 警戒:
                if (!防備)
                {
                    呈現顏色.SetTrigger("警戒");
                    防備 = true;
                }
                transform.Translate(Vector3.forward * Time.deltaTime * 移動速度);
                轉身方位 = Quaternion.LookRotation(玩家.transform.position - transform.position, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, 轉身方位, 轉身速度);
                警戒中();
                break;
            case NPC狀態 . 追擊:
                if (!跑步)
                {
                    跑步 = true;
                }
                transform.Translate(Vector3.forward * Time.deltaTime * 移動速度 * 4);
                轉身方位 = Quaternion.LookRotation(玩家.transform.position - transform.position, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, 轉身方位, 轉身速度);
                追擊中();
                break;
            case NPC狀態 . 返回:
                transform.Translate(Vector3.forward * Time.deltaTime * 移動速度 * 4);
                轉身方位 = Quaternion.LookRotation(初始座標 - transform.position, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, 轉身方位, 轉身速度);
                返回中();
                break;
        }
    }
    void 探查中()
    {

        威脅距離 = Vector3.Distance(玩家.transform.position, transform.position);
        if (威脅距離 < 攻擊範圍)
        {
            SceneManager.LoadScene("L2");
            暫停 = true;
            print("進入L2");
        }
        else if (威脅距離 < 自衛半徑)
        {
            目前狀態 = NPC狀態.追擊;
            呈現顏色.SetTrigger("追擊");
        }
        else if (威脅距離 < 警戒半徑)
        {
            目前狀態 = NPC狀態.警戒;
            呈現顏色.SetTrigger("警戒");
        }
        else if (威脅距離 < 遊走半徑)
        {
            目前狀態 = NPC狀態.移動;
            轉身方位 = Quaternion.LookRotation(初始座標 - transform.position, Vector3.up);
            呈現顏色.SetTrigger("移動");
        }
    }
    void 巡邏中()
    {

        威脅距離 = Vector3.Distance(玩家.transform.position, transform.position);
        返回距離 = Vector3.Distance(transform.position, 初始座標);
        if (威脅距離 < 攻擊範圍)
        {
            SceneManager.LoadScene("L2");
            暫停 = true;
            print("進入L2");
        }
        else if (威脅距離 < 自衛半徑)
        {
            目前狀態 = NPC狀態.追擊;
            呈現顏色.SetTrigger("追擊");
        }
        else if (威脅距離 < 警戒半徑)
        {
            目前狀態 = NPC狀態.警戒;
            呈現顏色.SetTrigger("警戒");
        }
        if (返回距離 > 遊走半徑)
        {
            轉身方位 = Quaternion.LookRotation(初始座標 - transform.position, Vector3.up);
        }
    }
    void 返回中()
    {
        返回距離 = Vector3.Distance(transform.position, 初始座標);
        if (返回距離 < 1.5f)
        {

            呈現顏色.SetTrigger("移動");

            跑步 = false;
            隨機狀態();
        }
    }
    void 警戒中()
    {

        噴火.gameObject.SetActive(true);
        威脅距離 = Vector3.Distance(玩家.transform.position, transform.position);
        if (威脅距離 < 自衛半徑)
        {
            防備 = false;
            噴火.gameObject.SetActive(false);
            目前狀態 = NPC狀態.追擊;
            呈現顏色.SetTrigger("追擊");
        }
        if (威脅距離 > 警戒半徑)
        {
            防備 = false;
            噴火.gameObject.SetActive(false);
            隨機狀態();
            呈現顏色.SetTrigger("觀察");
        }
    }
    void 追擊中()
    {

        威脅距離 = Vector3.Distance(玩家.transform.position, transform.position);
        返回距離 = Vector3.Distance(transform.position, 初始座標);
        if (威脅距離 < 攻擊範圍)
        {
            SceneManager.LoadScene("L2");
            暫停 = true;
            print("進入L2");
        }
        if (返回距離 > 追擊半徑 || 威脅距離 > 警戒半徑)
        {
            目前狀態 = NPC狀態.返回;
            呈現顏色.SetTrigger("返回");
        }
    }
}
