using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCLP : MonoBehaviour
{
    GameObject ���h;
    Color �p�F��m;
    void Start()
    {
        ���h = transform.parent.gameObject;
    }
    void Update()
    {
        this.GetComponent<Renderer>().material.color = �p�F��m;
        �p�F��m = ���h.GetComponent<Renderer>().material.color;
    }
}
