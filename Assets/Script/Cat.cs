using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public int type;
    float full = 5;
    float energy = 0;
    bool isFull;
    void Start()
    {
        float x = Random.Range(-8.5f, 8.5f);
        float y = 30;
        transform.position = new Vector3(x, y, 0);

        if (type == 1)
        {
            full = 10.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (energy < full)
        {
            if(type == 0)
            {
                transform.position += new Vector3(0, -0.005f, 0);
            }
            else if(type == 1)
            {
                transform.position += new Vector3(0, -0.003f, 0);
            }
            else if (type == 1)
            {
                transform.position += new Vector3(0, -0.01f, 0);
            }

            if (transform.position.y < -16.0f)
            {
                GameManager.I.gameOver();
            }
        }
        else
        {
            if (transform.position.x > 0)
            {
                transform.position += new Vector3(0.005f, 0, 0);
            }
            else
            {
                transform.position += new Vector3(-0.005f, 0, 0);
            }
            Destroy(gameObject,3);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Food")
        {
            if(energy< full)
            {
                energy += 1;
                Destroy(coll.gameObject);
                gameObject.transform.Find("Hungry/Canvas/Front").transform.localScale = new Vector3(energy/full, 1.0f, 1.0f);
            }
            else
            {
                if(isFull ==  false)
                {
                    GameManager.I.AddCat();
                    gameObject.transform.Find("Hungry").gameObject.SetActive(false);
                    gameObject.transform.Find("Full").gameObject.SetActive(true);
                    isFull = true;
                }
                
            }
        }
    }
}
