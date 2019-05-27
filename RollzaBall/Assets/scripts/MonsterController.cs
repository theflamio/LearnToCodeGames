using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterController : MonoBehaviour
{

    public int speed;
    public GameObject player;
   
    void Update () {
        Vector3 localPosition = player.transform.position - transform.position;
        localPosition = localPosition.normalized; // The normalized direction in LOCAL space
        transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
    }
}
