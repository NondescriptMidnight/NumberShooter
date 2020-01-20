using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject cannonBall;
    public AudioClip boomSound;
    public GameObject player;

    public float speed = 100f;
    private float lastShot = 0f;
    public float firingRate = 0.5f;

    private Vector2 diagonal = new Vector2(-1f, 1f);


    void Update()
    {

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > firingRate + lastShot)
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.PlayOneShot(boomSound);
                GameObject cannon = (GameObject)Instantiate(cannonBall, transform.position, Quaternion.Euler(-90,45,0));
                cannon.GetComponent<Rigidbody>().transform.rotation.SetLookRotation(transform.position + cannon.GetComponent<Rigidbody>().velocity);
                cannon.GetComponent<Rigidbody>().velocity = new Vector3 (0.5f, transform.forward.y + 0.2f,1f) * speed;
                Debug.Log(player.transform.eulerAngles.x);
                lastShot = Time.time;
            }
        }
    }

}