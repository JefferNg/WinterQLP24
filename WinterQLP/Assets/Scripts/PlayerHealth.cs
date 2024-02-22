using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{

    private int health;
    float deathTimer;
    float hitTimer;

    [SerializeField]
    float delayDeath;
    [SerializeField]
    float delaySceneReload;

    [SerializeField]
    int scene;

    [SerializeField]
    int maxHealth;

    [SerializeField]
    float flickerTime;

    [SerializeField]
    Color flickerColor;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    Color normalColor;

    bool hit = false; 

    public int getHealth()
    {
        return health;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public bool getHit()
    {
        return hit;
    }

    public void setHit(bool value)
    {
        hit = value;
    }

    public void setHealth(int value)
    {
        health = value;
    }

    private void Start()
    {
        health = maxHealth;
        normalColor = spriteRenderer.color;
    }

    private void Update()
    {
        if(health <= 0)
        {
            GetComponent<CharacterController2D>().enabled = false;
            deathTimer += Time.deltaTime; 
            if (deathTimer >= delayDeath)
            {
                spriteRenderer.enabled = false;
            }
            if(deathTimer >= delaySceneReload)
            {
                SceneManager.LoadScene(scene);
            }
        }
        else
        {
            deathTimer = 0;
        }
        if (hit)
        {
            hitTimer += Time.deltaTime;
        }
        if (hitTimer > flickerTime)
        {
            spriteRenderer.color = normalColor;
            hit = false;
            hitTimer = 0;
        }
    }

    public void isHit(int health_decrement)
    {
        if (hit)
        {
            return;
        }
        hit = true;
        health -= health_decrement;
        Debug.Log(health);
        spriteRenderer.color = flickerColor;
    }
}
