using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLP : MonoBehaviour
{
    public Transform[] �p�F���I;
    GameObject[] ���I;
    int ����;
    Color ����;
    void Start()
    {
        �p�F���I = GetComponentsInChildren<Transform>();
        ���I = GameObject.FindGameObjectsWithTag("Spot");
    }
    void Update()
    {
        for (���� = 0; ���� <= (�p�F���I.Length - 2); ����++)
        {
            �p�F���I[���� + 1].position =
            NPC.�ƥ�.�D���a����[����].transform.position;
        }
        foreach (var �D���a���� in ���I)
        {
            �D���a����.GetComponent<Renderer>().material.color =
            NPC.�ƥ�.�D���a����[0].
            GetComponent<Renderer>().material.color;
        }
    }
}
