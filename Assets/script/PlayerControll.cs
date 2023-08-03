using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] float torqueAmount = 12f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float boostSpeed = 30f;

    bool canMove = true;

    Rigidbody2D rb2D;
    SurfaceEffector2D surfaceEffector2D;

    // Start is called before the first frame update
    void Start()
    {
        
        rb2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove) {
            RaotoPlayer();
            BoostPlayer();
        }
    }

    // 通过 public 关键字暴露方法，让其他脚本可以调用
    public void DestroyControll() {
        canMove = false;
    }
    void BoostPlayer() {
        if(Input.GetKey(KeyCode.UpArrow)) {
            surfaceEffector2D.speed = boostSpeed;
        }else if(Input.GetKey(KeyCode.DownArrow)) {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RaotoPlayer() {
        if(Input.GetKey(KeyCode.RightArrow)) 
        {
            rb2D.AddTorque(-torqueAmount); // 添加扭矩
        } 
        else if(Input.GetKey(KeyCode.LeftArrow)) 
        {
            rb2D.AddTorque(torqueAmount); // 添加扭矩
        }
    }
}
