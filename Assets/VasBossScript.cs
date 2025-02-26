using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bot2 : MonoBehaviour
{
    int countHits = 0;
    float speed = 50;
    float force = 13;
    public Transform ball;
    public Transform aimTarget;
    public GameObject itemToActivate;
    public GameObject[] itemToActDeactivate;
    public AudioSource playsound;
    [SerializeField] UnityEvent onEnterEvent;

    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        targetPosition.x = ball.position.x;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2(Collider other)
    {
        if (other.CompareTag("Ball") && countHits < 15)
        {
            Vector3 dir = aimTarget.position - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force + new Vector3(0, 6, 0);
            playsound.Play();

            countHits++;
        }
        else if (countHits >= 15)
        {
            // Deactivate items
            itemToActDeactivate[0].SetActive(false); // Deactivate Indiana Jones theme
            itemToActDeactivate[1].SetActive(false); // Deactivate Ball

            // Activate Nooooooo
            itemToActivate.SetActive(true);

            // Start the coroutine to trigger the event after 3 seconds
            StartCoroutine(TriggerEventAfterDelay(3f)); // 3 seconds delay
        }
    }

    // Coroutine that triggers an event after a delay
    IEnumerator TriggerEventAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Call the event of your choice here
        onEnterEvent?.Invoke();
    }

    // Your custom event that will be triggered after the delay
    void TriggerYourEvent()
    {
        Debug.Log("Event triggered after 3 seconds!");
        // Add any custom logic you want to execute after the delay here
    }
}
