using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<SpriteRenderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }
}
