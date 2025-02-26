using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bot : MonoBehaviour
{
    int countHits = 0;
    float speed = 50;
    float force = 13;
    public Transform ball;
    public Transform aimTarget;
    public GameObject itemToActivate;
    public GameObject[] itemToActDeactivate;
    public AudioSource playsound;


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

    public void GoToNextScene()
    {
        SceneManager.LoadScene("YouWin");
    }

    IEnumerator DelaySome()
    {
        yield return new WaitForSeconds(8);
        //SceneManager.LoadScene("YouWin"); //change scene

        //For change scene make comments the bellow and uncomment the above
        Debug.Log("OK");
        itemToActDeactivate[2].SetActive(true);//activate Win Menu
        itemToActDeactivate[3].SetActive(true);//activate Win music
        itemToActDeactivate[4].SetActive(false);//deactivate Clippy
    }

    private void OnTriggerEnter(Collider other)
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
            //yield return new WaitForSeconds(5);
            itemToActDeactivate[0].SetActive(false);//deactivate Indiana Jones theme
            itemToActDeactivate[1].SetActive(false);//deactivate Ball
            itemToActivate.SetActive(true);//activate Nooooooo
            
            //itemToActDeactivate[2].SetActive(true);//activate Win theme
            //itemToActDeactivate[3].SetActive(false);//deactivate Clippy



            StartCoroutine (DelaySome()); //call delay and show menu 



        }
    }
}
