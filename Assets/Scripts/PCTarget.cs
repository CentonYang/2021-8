using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCTarget : MonoBehaviour
{
    public Transform[] �ϰl��;
    public static Vector3 ��m;
    public GameObject �ؼ�;
    GameObject ���a;
    int ����;
    float �Z��;
    void Start()
    {
        ���a = GameObject.FindGameObjectWithTag("Player");
        ���� = 0;
        ��m = �ϰl��[����].position;
        Instantiate(�ؼ�, ��m, transform.localRotation);
    }
    void Update()
    {
        �Z�� = Vector3.Distance(���a.transform.position, ��m);
        ��m = �ϰl��[����].position;
        �ؼ� = GameObject.FindGameObjectWithTag("Target");
        �ؼ�.transform.Rotate(0, 1.5f, 0);
        if (�Z�� < 1.5)
        {
            ���� = (���� + 1) % �ϰl��.Length;
        }
    }
}
