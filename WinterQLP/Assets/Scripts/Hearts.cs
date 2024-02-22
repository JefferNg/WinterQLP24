using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    [SerializeField]
    PlayerHealth playerHealth;

    [SerializeField]
    GameObject heart;

    [SerializeField]
    Vector2 initialPosition;

    [SerializeField]
    Vector2 offset;

    int num_hearts;

    List<GameObject> hearts = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        num_hearts = playerHealth.getMaxHealth();
        Vector2 position = initialPosition;
        for(int i=0; i<num_hearts; i++)
        {
            GameObject created_heart = Instantiate(heart, Vector3.zero, Quaternion.identity, gameObject.transform);
            created_heart.GetComponent<RectTransform>().anchoredPosition = position;
            position += offset;
            hearts.Add(created_heart);
        }
    }

    // Update is called once per frame
    void Update()
    {
        num_hearts = playerHealth.getHealth();
        for (int i=0; i<playerHealth.getMaxHealth(); i++)
        {
            if (i < num_hearts)
            {
                hearts[i].GetComponent<Image>().enabled = true;
            }
            else
            {
                hearts[i].GetComponent<Image>().enabled = false;
            }
        }
    }
}
