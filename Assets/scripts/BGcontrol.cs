using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGcontrol : MonoBehaviour
{
    public Transform[] childtf;
    public obstacleManager m;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            childtf[i] = transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            childtf[i].localPosition = childtf[i].localPosition - (new Vector3(m.movespeed * Time.deltaTime*0.5f, 0f, 0f));
            if (childtf[i].localPosition.x < -12f)
            {
                childtf[i].localPosition = childtf[i].localPosition + new Vector3(25.9f, 0f, 0f);
            }
        }
    }
}
