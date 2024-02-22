using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class FallDeath : MonoBehaviour
{
    [SerializeField]
    float y;

    [SerializeField]
    int scene;

    float deathTimer;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    float delaySceneReload;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < y)
        {
            GetComponent<CharacterController2D>().enabled = false;
            deathTimer += Time.deltaTime;
            spriteRenderer.enabled = false;
            if (deathTimer >= delaySceneReload)
            {
                SceneManager.LoadScene(scene);
            }
        }
    }
}
