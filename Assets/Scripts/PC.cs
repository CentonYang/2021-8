using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    public Life �ͩR��;
    float ��q;
    int �̤j�� = 100;
    void Start()
    {
        ��q = �̤j��;
        �ͩR��.��q�W��(�̤j��);
        DontDestroyOnLoad(this.gameObject);
    }
    public void ����(float �ˮ`��)
    {
        if (��q > 0 && ��q <= �̤j��)
        {
            ��q -= �ˮ`��;
            �ͩR��.��q�Ѿl(��q);
        }
    }
    public void �ɦ�(float ��_��)
    {
        if (��q >= 0 && ��q < �̤j��)
        {
            ��q += ��_��;
            �ͩR��.��q�Ѿl(��q);
        }
    }
    void OnCollisionEnter(Collision �y�H)
    {
        if (�y�H.gameObject.tag == "Hunter" && NPC.�k�� == false)
        {
            ����(20);
            print(" ���� ");
        }
    }
    void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.TransformVector(0, GetComponent<Rigidbody>().velocity.y, Input.GetKey(KeyCode.W) ? 3 : Input.GetKey(KeyCode.S) ? -2 : 0);
        transform.Rotate(0, (Input.GetKey(KeyCode.A) ? -80 : Input.GetKey(KeyCode.D) ? 80 : 0) * Time.deltaTime, 0);
        GetComponent<Rigidbody>().AddForce(new Vector3(0, Input.GetKeyDown(KeyCode.Space) ? 3 : 0, 0), ForceMode.Impulse);
        if (transform.position.y < -1) transform.position = Vector3.up;
        if (NPC.�k�� == true)
        {
            �ɦ�(20);
            print(" �ɦ� ");
        }
    }
}