using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public float JumpPower = 10;
    public int itemCount;
    public GameManagerLogic manager;

    bool isJump;
    Rigidbody rigid;

    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, JumpPower, 0), ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
            isJump = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);
        }
        else if (other.tag == "Point")
        {
            if(itemCount == manager.totaItemCount)
            {
                if (manager.stage ==6)
                    SceneManager.LoadScene(0);
                else
                {
                    manager.stage = manager.stage + 1;
                    SceneManager.LoadScene(manager.stage);
                }

            }
            else
            {
                SceneManager.LoadScene(manager.stage);
            }
            
                
        }
    }

}
    