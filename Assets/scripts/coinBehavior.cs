using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinBehavior : MonoBehaviour
{
    private obstacleManager mgr;
    public void setMgr(obstacleManager m)
    {
        mgr = m;
        mgr.resetEvent.AddListener(this.deleteself);
    }

    private void Start()
    {
        gameObject.transform.position = new Vector3(10, Random.Range(-3, 4), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (mgr.start)
        {
            transform.position += new Vector3(-mgr.movespeed * Time.deltaTime, 0, 0);
        }
        if (transform.position.x < -10)
        {
            deleteself();
        }
    }
    private void deleteself()
    {
        mgr.resetEvent.RemoveListener(this.deleteself);
        Destroy(gameObject);
    }
}
