using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    string buttonName;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletSpawner;
    [SerializeField] float sensitivity;

    [SerializeField] private float magnitude;

    [SerializeField] private float coolDown;

    float timer = 0f;

    bool alreadyShot = false;
    // Start is called before the first frame update
    void Start()
    {
        sensitivity = Mathf.Max(0, sensitivity); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis(buttonName) > sensitivity && !alreadyShot)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.position, Quaternion.identity);
            if (gameObject.GetComponent<CharacterController2D>().getFacingRight())
            {
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * magnitude;
            }
            else
            {
                bullet.GetComponent<Rigidbody2D>().velocity = -transform.right * magnitude;
            }
            alreadyShot = true;
            timer = 0f;
        }
        if (alreadyShot)
        {
            timer += Time.deltaTime;
            if(timer > coolDown)
            {
                alreadyShot = false;
            }
        }
    }
}
