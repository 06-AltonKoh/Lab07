using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject playerob;
    private Animation thisAnimation;

    public int PointCount;
    public Text Pointtxt;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if(playerob.transform.position.y <= 3.5 && playerob.transform.position.y >= -3.5)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                thisAnimation.Play();
                GetComponent<Rigidbody>().AddForce(0, 3.5f, 0, ForceMode.Impulse);
            }
        }
        else
        {
            SceneManager.LoadScene("GameOverScene");
        }
            
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Point")
        {
            PointCount += 1;
            Pointtxt.text = "SCORE: " + PointCount;
        }
    }
}
