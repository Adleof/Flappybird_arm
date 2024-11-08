using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.RenderGraphModule;
using UnityEngine.InputSystem;

public class actorControl : MonoBehaviour
{
    public Material mat;
    public Animator anm;
    public cam_shake_controller cam_shake;
    public obstacleManager mgr;
    private Vector2 mousepos;
    private Rigidbody rb;
    public bool buffed;
    public float buffend;
    public float mgrbasespeed;
    public int health;
    private float lasty;
    public bool start;
    // Start is called before the first frame update

    public void startplayer()
    {
        start = true;
    }
    public void resetplayer()
    {
        buffed = false;
        mgrbasespeed = 4f;
        update_mgr_movespeed();
        mat.SetFloat("_alpha", 0);
        health = 10;
        buffend = 0;
        transform.position = new Vector3(-5.68f, -0.03f, 0.57f);
        transform.rotation = Quaternion.identity;
    }
    public void stopplayer()
    {
        start = false;
    }
    public void mouse_pos(InputAction.CallbackContext context)
    {
        mousepos = context.ReadValue<Vector2>();
        mousepos.x = (mousepos.x-1920/2) / 108f;
        mousepos.y = (mousepos.y - 1080 / 2) / 108f;
    }
    private void update_mgr_movespeed()
    {
        mgr.movespeed = buffed ? mgrbasespeed*2f : mgrbasespeed;
        anm.SetFloat("playaniSpeed", mgr.movespeed/3f);
    }
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        buffed = false;
        mgrbasespeed = 4f;
        update_mgr_movespeed(); 
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            float dy = mousepos.y - lasty;
            lasty = mousepos.y;
            transform.position = new Vector3(mousepos.x, mousepos.y, 0);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, dy * 280));
            float buftimeleft = buffend - Time.realtimeSinceStartup;
            if (buftimeleft < 0)
            {
                if (buffed)
                {
                    buffed = false;
                    update_mgr_movespeed();
                    mat.SetFloat("_alpha", 0);
                }
            }
            else
            {
                if (buftimeleft > 2.127f)
                {
                    mat.SetFloat("_alpha", 1);
                }
                else if (buftimeleft > 0.125f)
                {
                    mat.SetFloat("_alpha", Mathf.Sin(buftimeleft * 4 * MathF.PI) * 0.2f + 0.8f);
                }
                else
                {
                    mat.SetFloat("_alpha", buftimeleft * 8f);
                }
            }


            if (mgrbasespeed < 4)
            {
                mgrbasespeed += 1f * Time.deltaTime;
                update_mgr_movespeed();
            }
        }
    }
    private void FixedUpdate()
    {
        //rb.velocity = ((new Vector3(mousepos.x, mousepos.y, 0)) - rb.position)*50f;
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("collide");
        if (other.tag == "coinUp")
        {
            mgrbasespeed += 1;
            update_mgr_movespeed();
        }
        else if (other.tag == "coinDown")
        {
            buffed = true;
            buffend = Time.realtimeSinceStartup + 5;
            update_mgr_movespeed();
        }
        else
        {
            cam_shake.shakeCam(0.025f * mgr.movespeed);
            if (!buffed)
            {
                mgrbasespeed /= 2;
                //if (mgrbasespeed < 4)
                //{
                //    mgrbasespeed = 4;
                //}
                update_mgr_movespeed();

                health -= 1;
            }
        }
        Destroy(other.gameObject);
    }
}
