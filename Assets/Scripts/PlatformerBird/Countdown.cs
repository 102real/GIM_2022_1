﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float setTime = 60.0f;
    [SerializeField] Text countdownText;
    void Start()
    {
        countdownText.text = setTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (setTime > 0)
        {
            setTime -= Time.deltaTime;
        }
        else if (setTime <= 0)
        {
            Time.timeScale = 0.0f;
            FindObjectOfType<GameManager2D>().GameOver();
        }
        countdownText.text = Mathf.Round(setTime).ToString();
    }
    
    // Time Add 5Clock
    public void TimeAdd()
    {
        setTime += 5;
    }
}
