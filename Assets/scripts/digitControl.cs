using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class digitControl : MonoBehaviour
{
    public GameObject[] childs;
    public int curnum;
    // Start is called before the first frame update
    void Start()
    {
    }
    /*
     * -1 for no display
     */
    public void resetDigits()
    {
        curnum = -1;
        for (int i = 0; i < 10; i++)
        {
            childs[i] = transform.GetChild(i).gameObject;
            childs[i].SetActive(false);
        }
    }
    public void dispNum(int num)
    {
        if (num >= 0 && num <= 9)
        {
            if (curnum >= 0)
            {
                childs[curnum].SetActive(false);
            }
            childs[num].SetActive(true);
            curnum = num;
        }
        else
        {
            if (curnum >= 0)
            {
                childs[curnum].SetActive(false);
                curnum = num;
            }
        }
    }
}
