using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public AudioClip endBuzzer;

    [SerializeField]
    public Stat health;
    public static float speed;
    private bool hasPlayed = false;
	// Use this for initialization
	private void Awake() {
        health.Initialize();
	}

    private void Start()
    {
        speed = 1f;
    }
	
	// Update is called once per frame
	public void Update () {
        health.CurrentVal -= speed * Time.deltaTime;
        if (health.CurrentVal == 0)
        {
            Invoke("GameOver", 3f);
            if (!hasPlayed)
            {
                AudioSource.PlayClipAtPoint(endBuzzer, Camera.main.transform.position, 1f);
                hasPlayed = true;
            }
        }
    }
    void GameOver()
    {
        Application.LoadLevel(1);
    }
}
