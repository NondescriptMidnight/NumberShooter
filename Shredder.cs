using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{

    void OnCollisionEnter(Collision objCol)
    {
            Destroy(objCol.gameObject);
    }
}
