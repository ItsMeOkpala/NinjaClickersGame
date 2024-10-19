using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableScript : MonoBehaviour
{

    public float minInterval, maxInterval;
    public AnimationSet[] animationsets;


    Animator myAnimator;
    bool isClickable;
    int index;
    float timestamp;
    Score score;

    [System.Serializable]
    public class AnimationSet
    {
        public string birth, death;
        public int scorePoints, statPoints, statIndex;
    }


        // Start is called before the first frame update
        void Start()
        {
            myAnimator = GetComponent<Animator>();
            score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        }

            // Update is called once per frame
            void Update()
            {
                if(!isClickable) //isClickable == false
                {
                    if(timestamp == 0) //Randomly set new future timestamp
                    {
                        timestamp = Random.Range(minInterval, maxInterval) + Time.time;
                    }

                    if(timestamp <= Time.time) //Birth
                    {
                        isClickable = true;
                        timestamp = 0;
                        index = Random.Range(0, animationsets.Length);
                        myAnimator.Play(animationsets[index].birth, -1, 0);
                    }
                }
            }

                private void OnMouseDown()
                {
                    if(isClickable)
                    {
                        myAnimator.Play(animationsets[index].death);
                        score.points += animationsets[index].scorePoints;//Score

                        if (animationsets[index].statPoints != 0)//Stats
                            {
                                int i = animationsets[index].statIndex;
                                score.stats[i].points += animationsets[index].statPoints;
                            }

                        isClickable = false;
                    }
                }

        public void DeactivateClickable()
        {
            isClickable = false;
        }
}

