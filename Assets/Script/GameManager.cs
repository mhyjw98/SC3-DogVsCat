using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject dog;
    public GameObject food;
    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject pirateCat;
    public GameObject retryBtn;

    public Text levelText;
    public GameObject levelFront;

    public static GameManager I;

    int level = 0;
    int cat = 0;

    void Awake()
    {
        I = this;
    }
    void Start()
    {
        Time.timeScale = 1f;
        InvokeRepeating("MakeFood", 0, 0.05f);
        InvokeRepeating("makeCat", 0.0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeFood()
    {
        float x = dog.transform.position.x;
        float y = dog.transform.position.y + 2;
        Instantiate(food, new Vector3(x, y, 0), Quaternion.identity);
    }

    void makeCat()
    {
        Instantiate(normalCat);

        if (level == 1)
        {
            float p = Random.Range(0, 10);
            if (p < 2) Instantiate(normalCat);
        }
        else if (level >= 2)
        {
            float p = Random.Range(0, 10);
            if (p < 5) Instantiate(normalCat);
        }
        else if (level >= 3)
        {
            float p = Random.Range(0, 10);
            if (p < 5) Instantiate(normalCat);

            Instantiate(fatCat);
        }
        else if (level >= 4)
        {
            float p = Random.Range(0, 10);
            if (p < 5) Instantiate(normalCat);

            Instantiate(fatCat);
            Instantiate(pirateCat);
        }
    }

    public void gameOver()
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void AddCat()
    {
        cat += 1;
        level = cat / 5;

        levelText.text = level.ToString();
        levelFront.transform.localScale = new Vector3((cat - level * 5) / 5.0f, 1.0f, 1.0f);
  
    }
}
