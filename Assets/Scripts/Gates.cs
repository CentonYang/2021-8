using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    public GameObject 出入;
    void OnCollisionEnter(Collision PC)
    {
        if (PC.gameObject.tag == "Player")
        {
            出入.gameObject.GetComponent<Collider>().isTrigger = true;
            PC.transform.position = 出入.transform.position;
        }
    }
    void OnTriggerExit(Collider other)
    {
        GetComponent<Collider>().isTrigger = false;
    }
}
