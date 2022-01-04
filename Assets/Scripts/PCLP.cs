using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCLP : MonoBehaviour
{
    GameObject ¤÷¼h;
    Color ¹p¹F¦â±m;
    void Start()
    {
        ¤÷¼h = transform.parent.gameObject;
    }
    void Update()
    {
        this.GetComponent<Renderer>().material.color = ¹p¹F¦â±m;
        ¹p¹F¦â±m = ¤÷¼h.GetComponent<Renderer>().material.color;
    }
}
