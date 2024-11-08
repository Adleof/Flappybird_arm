using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class UIdisp : MonoBehaviour
{
    public TextMeshProUGUI curscoreDisp;
    public TextMeshProUGUI maxscoreDisp;
    private DepthOfField dof;
    public Volume volsetting;
    public GameObject gamemodeui;
    public GameObject homeui;
    public GameObject endganeui;
    public healthDisp hd;
    public actorControl player;
    public obstacleManager mgr;
    public digitControl[] dgroup;//low digit to high digit
    private TextMeshProUGUI u;
    private bool playing;
    private float maxscore;
    // Start is called before the first frame update
    void Start()
    {
        u = gameObject.GetComponent<TextMeshProUGUI>();
        playing = false;
        volsetting.profile.TryGet<DepthOfField>(out dof);
        maxscore = 0;
    }
    public void restart()
    {
        gamemodeui.SetActive(true);
        hd.recover();
        player.resetplayer();
        player.startplayer();
        mgr.resetgame();
        mgr.startgame();
        for (int i = 0; i < dgroup.Length; i++)
        {
            dgroup[i].resetDigits();
        }
        homeui.SetActive(false);
        endganeui.SetActive(false);
        playing = true;
        dof.active = false;
    }
    public void gohome()
    {
        homeui.SetActive(true);
        endganeui.SetActive(false);
        mgr.resetgame(); 
        player.resetplayer();
        dof.active = false;
    }
    public void stopgame()
    {
        player.stopplayer();
        mgr.stopgame();
        float score = mgr.score;
        gamemodeui.SetActive(false);
        endganeui.SetActive(true);
        playing = false;
        dof.active = true;
        curscoreDisp.text = score.ToString("F0");
        if(score > maxscore)
        {
            maxscore = score;
        }
        maxscoreDisp.text = maxscore.ToString("F0");
    }
    private void displayDigits(int sco)
    {
        for (int i = 0; i < dgroup.Length; i++)
        {
            if (sco == 0)
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
    }
    // Update is called once per frame
    void Update()
    {
        //u.text = "Health:"+player.health.ToString() + "\r\nScore:" + mgr.score.ToString("F0") + "\r\nBasespeed:" + player.mgrbasespeed.ToString("F0") + "\r\nBuff time left:" + Mathf.Max(0,(player.buffend - Time.realtimeSinceStartup)).ToString("F1");
        if (playing)
        {
            displayDigits((int)mgr.score);
            if (player.health < hd.curhealth)
            {
                hd.decreaseHealth();
            }
            if (player.health <= 0)
            {
                stopgame();
            }
        }
    }
}
