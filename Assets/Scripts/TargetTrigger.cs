using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider pc)
    {
        if (pc.gameObject.tag == "Player")
        {
            NPC.¶}©l°kÂ÷ = Time.time;
            NPC.°kÂ÷ = true;
            Destroy(gameObject);
            Instantiate(this, PCTarget.¦ì¸m, Quaternion.identity);
        }
    }
}
