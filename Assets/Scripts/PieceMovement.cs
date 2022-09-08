using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float fallingSpeed = 1;
    private void Start()
    {
        fallingSpeed = 100;
    }
    private void Update()
    {
        Fall();
        Movement();
    }

    private void Movement()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            VerifyPositionInTable(1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            VerifyPositionInTable(-1);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            fallingSpeed = 600;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            fallingSpeed = 100;
        }
    }

    private void VerifyPositionInTable(int direccion)
    {
        bool move = false;
        foreach (var pT in SpawnPieces.instance.table)
        {
            Debug.Log(pT.position.z + "  **   " +transform.position.z );
            if (pT.position.z == transform.position.z && !move)
            {
                if (direccion==1 && pT.position.z!= 1.88031f)
                {
                    transform.position = new Vector3(transform.position.x,transform.position.y,
                        transform.position.z+0.3f);
                }
                else if(direccion == -1 && pT.position.z != -0.8196901f)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y,
                                            transform.position.z - 0.3f);
                }
                move = true;
            }
        }
    }

    private void Fall()
    {
        rigidbody.velocity = Vector3.down * fallingSpeed * Time.deltaTime;
    }
}
