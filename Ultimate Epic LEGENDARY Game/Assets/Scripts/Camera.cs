using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform Player;
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, Player.transform.position.y, 0.05f),
            Mathf.Lerp(transform.position.x, Player.transform.position.y, 0.05f),
            -1 );
    }
}
