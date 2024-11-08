using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleObj : MonoBehaviour
{
    public float dist;
    public float speed;
    public float ypos;
    private obstacleManager mgr;

    public void setDist_Y_spd(float dist, float ypos)
    {
        GameObject chi1 = gameObject.transform.GetChild(0).gameObject;
        GameObject chi2 = gameObject.transform.GetChild(1).gameObject;
        chi1.transform.SetLocalPositionAndRotation(new Vector3(0, dist, 0),Quaternion.identity);
        chi2.transform.SetLocalPositionAndRotation(new Vector3(0, -dist, 0), Quaternion.identity);
        transform.position = new Vector3(10, ypos, 0);
    }
    public void setManager(obstacleManager m)
    {
        mgr = m;
    }

    // Update is called once per frame
    void Update()
    {
        //setDist(dist);
        transform.position += new Vector3(-mgr.movespeed * Time.deltaTime, 0, 0);
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
