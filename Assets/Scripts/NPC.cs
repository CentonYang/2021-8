using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPC: MonoBehaviour {
public List<NavMeshAgent> �D���a���� = new List<NavMeshAgent>();
GameObject ���a;
Transform[] �_�l����;
public Vector3[] �_�l�y��;
int ����;
public static bool �k��;
public static float �}�l�k��;
public int �k�����;
public static NPC �ƥ�;
public static bool �k��;
void Start()
{
    ���a = GameObject.FindGameObjectWithTag("Player");
    �ƥ� = this;
    �k�� = false;
    �_�l���� = GetComponentsInChildren<Transform>();
    for (���� = 0; ���� <= (�_�l�y��.Length - 1); ����++)
    {
        �_�l�y��[����] = �_�l����[���� + 1].position;
    }
    �l��();
}
void �l��()
{
    foreach (var �l���� in �D���a����)
    {
        �l����.SetDestination(���a.transform.position);
        �l����.GetComponent<Renderer>().material.color = Color.red;
    }
}

void ���}()
{
    float �Z��;

    if (Time.time - �}�l�k�� > �k�����)
    {
        �k�� = !�k��;
    }
    for (���� = 0; ���� <= (�D���a����.Count - 1); ����++)
    {
        �D���a����[����].SetDestination(�_�l�y��[����]);
        �Z�� = Vector3.Distance(���a.transform.position,
        �D���a����[����].transform.position);
        if (�Z�� < 1.0f)
        {
            �D���a����[����].transform.position = �_�l�y��[����];
            �k�� = true;
        }
    }

    foreach (var �k���� in �D���a����)
    {
        �k����.GetComponent<Renderer>().material.color = Color.blue;
    }
}
void Update()
{
    if (!�k��)
    {
        �l��();
    }
    else
    {
        �k�� = true;
        �k�� = false;
        ���}();
    }
}
}
