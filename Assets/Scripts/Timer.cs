using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timer;
    public float duration;
    public Animator gameOverAnimator;
    public string gameOverClipName;

    bool gameover;

    // Update is called once per frame
    void Update()
    {
        if (!gameover) //!gameOver -> gameOver ==false
        {
            duration -= Time.deltaTime; //Reduces the time left, duration = duration - Time.deltaTime; (Subtracting time from the duuration as it goes by).
            duration = Mathf.Clamp(duration, 0, Mathf.Infinity); //Clamps relate to Min or Max values, This linexcode is to make sure it doesnt go below zero.
            timer.text = Mathf.Ceil(duration) + "";

            if(duration ==  0)
            {
                gameOverAnimator.Play(gameOverClipName);
                gameover = true;
            }

        }
    }
}
