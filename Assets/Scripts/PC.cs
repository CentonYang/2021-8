using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    public Life ネ㏑;
    float ﹀秖;
    int 程 = 100;
    void Start()
    {
        ﹀秖 = 程;
        ネ㏑.﹀秖(程);
        DontDestroyOnLoad(this.gameObject);
    }
    public void ア﹀(float 端甡)
    {
        if (﹀秖 > 0 && ﹀秖 <= 程)
        {
            ﹀秖 -= 端甡;
            ネ㏑.﹀秖逞緇(﹀秖);
        }
    }
    public void 干﹀(float 確)
    {
        if (﹀秖 >= 0 && ﹀秖 < 程)
        {
            ﹀秖 += 確;
            ネ㏑.﹀秖逞緇(﹀秖);
        }
    }
    void OnCollisionEnter(Collision 聐)
    {
        if (聐.gameObject.tag == "Hunter" && NPC.発瞒 == false)
        {
            ア﹀(20);
            print(" ア﹀ ");
        }
    }
    void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.TransformVector(0, GetComponent<Rigidbody>().velocity.y, Input.GetKey(KeyCode.W) ? 3 : Input.GetKey(KeyCode.S) ? -2 : 0);
        transform.Rotate(0, (Input.GetKey(KeyCode.A) ? -80 : Input.GetKey(KeyCode.D) ? 80 : 0) * Time.deltaTime, 0);
        GetComponent<Rigidbody>().AddForce(new Vector3(0, Input.GetKeyDown(KeyCode.Space) ? 3 : 0, 0), ForceMode.Impulse);
        if (transform.position.y < -1) transform.position = Vector3.up;
        if (NPC.耴 == true)
        {
            干﹀(20);
            print(" 干﹀ ");
        }
    }
}