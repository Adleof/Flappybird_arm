using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class obstacleManager : MonoBehaviour
{
    public UnityEvent resetEvent;
    public obstacleObj obstacleObj;
    public coinBehavior speedupprefab;
    public coinBehavior speedwornprefab;
    public float movespeed;
    public float dist_betw_obs;
    public float score;
    private float distnow;
    private float distm5now;
    public bool start;
    // Start is called before the first frame update
    public void resetgame()//reset obstacles and coins
    {
        distnow = 0; distm5now = 0;
        score = 0;
        resetEvent.Invoke();
        movespeed = 4;
    }
    public void stopgame()
    {
        start = false;
        movespeed = 0;
    }
    public void startgame()
    {
        start = true;
    }
    private void Start()
    {
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if (score - Mathf.Repeat(score, 10) > distnow)
            {
                distnow = score - Mathf.Repeat(score, 10);
                obstacleObj newo = Instantiate(obstacleObj);
                newo.setDist_Y_spd(5f + Random.Range(0f, 1f) * 1f, Random.Range(-1f, 1f) * 2f);
                newo.setManager(this);
            }
            if (score - 5 - Mathf.Repeat(score - 5, 10) > distm5now)
            {
                distm5now = score - 5 - Mathf.Repeat(score - 5, 10);
                if (Random.Range(0f, 1f) > 0.5f)
                {
                    //coinBehavior newc = Instantiate(speedupprefab);
                    //newc.setMgr_typ(this, 1);
                    if (Random.Range(0f, 1f) > 0.5f)
                    {
                        coinBehavior newc = Instantiate(speedupprefab);
                        newc.setMgr(this);
                    }
                    else
                    {
                        coinBehavior newc = Instantiate(speedwornprefab);//power up pill
                        newc.setMgr(this);
                    }
                }
            }
            score += Time.deltaTime * movespeed;
        }
    }
}
