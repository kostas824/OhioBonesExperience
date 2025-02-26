using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   // public Transform aimTarget;
    public Transform[] targets;
    float speed = 4;
    float force = 20;

    public AudioSource playsound;

    bool hitting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 PickTarget()
    {
        int randomValue = Random.Range(0, targets.Length);
        return targets[randomValue].position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 dir = PickTarget() - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force + new Vector3(0, 6, 0);
            playsound.Play();
        }
    }
        
}
