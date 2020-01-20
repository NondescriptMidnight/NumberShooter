using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    public float speed = -5.0f;
    private Vector3 currPos;

    public AudioClip popSound;
    public AudioClip itemDescript;

    public GameObject popAni;
    public Player player;

    public int scoreValue = 1;

    void Start()
    {
        currPos = transform.position;
    }

    void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
    }

    void OnCollisionEnter(Collision objCol)
    {
        if (objCol.gameObject.tag == "arrow")
        {
            Debug.Log("ding");
            Die();
        }
    }
    void Die()
    {
        player = GameObject.Find("Player (1)").GetComponent<Player>();
        ScoreTracker.scoreNum++;
        speed -= 0.5f;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GameObject pop = Instantiate(popAni, transform.position, Quaternion.identity) as GameObject;
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(popSound);
        audio.PlayOneShot(itemDescript);
        Destroy(pop, 0.5f);
        Destroy(gameObject, itemDescript.length);
    }
}
