using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Life : MonoBehaviour
{
    public Slider 血量計;
    public Image 填色;
    public void 血量上限(float blood)
    {
        血量計.maxValue = blood;
        血量計.value = blood;
    }
    public void 血量剩餘(float blood)
    {
        血量計.value = blood;
    }
}