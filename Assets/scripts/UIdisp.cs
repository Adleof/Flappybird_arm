using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIdisp : MonoBehaviour
{
    public healthDisp hd;
    public actorControl player;
    public obstacleManager mgr;
    public digitControl[] dgroup;//low digit to high digit
    private TextMeshProUGUI u;
    // Start is called before the first frame update
    void Start()
    {
        //u = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //u.text = "Health:"+player.health.ToString() + "\r\nScore:" + mgr.score.ToString("F0") + "\r\nBasespeed:" + player.mgrbasespeed.ToString("F0") + "\r\nBuff time left:" + Mathf.Max(0,(player.buffend - Time.realtimeSinceStartup)).ToString("F1");
        int sco = (int)mgr.score;
        for (int i = 0; i < dgroup.Length; i++)
        {
            if(sco == 0)
            {
                break;
            }
            int dig = sco % 10;
            if (dgroup[i].curnum != dig)
            {
                dgroup[i].dispNum(dig);
            }
            sco = sco / 10;
        }
        if ( player.health < hd.curhealth)
        {
            hd.decreaseHealth();
        }


    }
}
