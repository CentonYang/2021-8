using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Life : MonoBehaviour
{
    public Slider ��q�p;
    public Image ���;
    public void ��q�W��(float blood)
    {
        ��q�p.maxValue = blood;
        ��q�p.value = blood;
    }
    public void ��q�Ѿl(float blood)
    {
        ��q�p.value = blood;
    }
}