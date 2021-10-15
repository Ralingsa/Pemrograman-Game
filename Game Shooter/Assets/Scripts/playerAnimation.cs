using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    public float speed = 4, rotSpeed = 80,
                    rot = 0f, gravitiy = 8;
    Animator anim;
    Vector3 moveDir = Vector3.zero;
    CharacterController controller;

    void attack()
    {
        StartCoroutine(attackRoutine());
    }

    void swapAk47()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            anim.SetBool("switchWeapon", true);
            anim.SetInteger("condition", 3);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            anim.SetBool("switchWeapon", false);
            anim.SetInteger("condition", 0);
        }
    }

    void swapShotgun()
    {
        if (Input.GetKey(KeyCode.Alpha2))
        {
            anim.SetBool("switchWeapon", true);
            anim.SetInteger("condition", 3);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            anim.SetBool("switchWeapon", false);
            anim.SetInteger("condition", 0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        getInput();
        swapAk47();
        swapShotgun();
    }

    void getInput()
    {
        if (Input.GetButton("Fire1"))
        {
            if (anim.GetBool("run") == true)
            {
                anim.SetBool("run", false);
                anim.SetInteger("condition", 0);
            }
            if (anim.GetBool("run") == false)
            {
                attack();
            }
        }
    }

    void movement()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (anim.GetBool("shoot") == true)
                {
                    return;
                }
                else if (anim.GetBool("shoot") == false)
                {
                    anim.SetBool("run", true);
                    anim.SetInteger("condition", 1);
                    moveDir = new Vector3(0, 0, 1);
                    moveDir *= speed;
                    moveDir = transform.TransformDirection(moveDir);
                }
            }
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetBool("run", false);
                anim.SetInteger("condition", 1);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }
        }
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }

    IEnumerator attackRoutine()
    {
        anim.SetBool("shoot", true);
        anim.SetInteger("condition", 2);
        yield return new WaitForSeconds(0.5f);
        anim.SetInteger("condition", 0);
        anim.SetBool("shoot", false);
    }
}
