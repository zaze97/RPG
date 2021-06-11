using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator anim;

    //BlendTreeZ方向动画的阈值
    private float BlendMove=5.7f;
    private bool Switching=false;
    private float SwitchingTime = 0;
    private int speedZID = Animator.StringToHash("MoveZ");
    private int speedRotateID = Animator.StringToHash("SpeedRotate");

    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        float v = 0, h = 0;
        v = Input.GetAxis("Vertical");
       // if (v >= 4.38f/ BlendMove)
      //  {
            h = Input.GetAxis("Horizontal");
       // }
        /*        if (v != 0 && anim.GetCurrentAnimatorStateInfo(0).IsName("Locomotion"))
                {
                    SwitchingTime +=Time.deltaTime;
                    if (SwitchingTime >= 2)
                    {
                        Switching = true;
                    }
                }
                else
                {
                    SwitchingTime = 0;
                    Switching = false;
                }
                BlendMove=v>=1&&?*/
        anim.SetFloat(speedZID, v * BlendMove);
        anim.SetFloat(speedRotateID, h * 46);
        //anim.SetFloat(speedRotateID, Input.GetAxis("Horizontal") * 126);
        //transform.Translate(h * Time.deltaTime, 0, v*Time.deltaTime);
    }
}
