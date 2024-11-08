using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthDisp : MonoBehaviour
{
    public GameObject[] childs;
    public int curhealth;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void decreaseHealth()
    {
        if (curhealth <= 0)
        {
            return;
        }
        childs[curhealth - 1].SetActive(false);
        curhealth -= 1;
    }
    public void recover()
    {
        for (int i = 0; i < 10; i++)
        {
            childs[i] = transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < 10; i++)
        {
            childs[i].SetActive(true);
        }
        curhealth = 10;
    }
}
