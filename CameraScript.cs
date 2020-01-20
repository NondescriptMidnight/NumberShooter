using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {


    Transform player;

    float offSetX;
    float offSetY;
    float offSetRotX;

    // Use this for initialization
    void Start()
    {
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");

        if (playerGO == null)
        {
            Debug.LogError("couldn't find an object with tag");
            return;
        }

        player = playerGO.transform;

        offSetX = transform.position.x - player.position.x;
        offSetY = transform.position.y - player.position.y;
        offSetRotX = transform.rotation.x - player.transform.rotation.x;
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            Vector3 cameraPos = transform.position;
            Quaternion cameraRot = transform.rotation;
            cameraPos.x = player.position.x + offSetX;
            cameraPos.y = player.position.y + offSetY;
            cameraRot.x = player.rotation.x + offSetRotX;
            transform.position = cameraPos;
            transform.rotation = cameraRot;
        }

    }
}
