using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider pc)
    {
        if (pc.gameObject.tag == "Player")
        {
            NPC.�}�l�k�� = Time.time;
            NPC.�k�� = true;
            Destroy(gameObject);
            Instantiate(this, PCTarget.��m, Quaternion.identity);
        }
    }
}
