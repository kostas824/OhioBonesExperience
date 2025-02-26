using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //public Transform Spawnpoint;
    public GameObject item;
    public GameObject collid;

    void OnTriggerEnter() 
    {
        item.SetActive(true);
        Destroy(collid);
    }
}
