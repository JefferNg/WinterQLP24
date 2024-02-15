using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    GameObject playerGameObject;
    Vector3 playerPosition;
    Vector3 difference;

    [SerializeField]
    float time;

    // Start is called before the first frame update
    void Start()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        playerPosition = playerGameObject.transform.position;
        difference = transform.position - playerPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerPosition = playerGameObject.transform.position;
        float move_rate = Vector3.Distance(transform.position, playerPosition) / time;
        transform.position = Vector3.Lerp(transform.position, difference + playerPosition, move_rate);
    }
}


