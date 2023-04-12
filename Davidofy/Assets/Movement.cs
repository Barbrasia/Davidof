using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterScript
{
public class Movement  : MonoBehaviour
{

    public float speed;
    public Rigidbody rb;

        public float vertMove;
        public float horMove;
        public float jumpForce;
        public int jumpCounting;

        private void Update()
        {
            horMove = Input.GetAxis("Horizontal");
            vertMove = Input.GetAxis("Vertical");

            if(Input.GetKeyDown(KeyCode.Space) && jumpCounting <2)
            {
                jumpCounting++;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Force);

            }
        }
        void FixedUpdate()
    {

            // transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * speed);
            rb.MovePosition(transform.position + new Vector3(horMove * speed, 0f, vertMove * speed));
            
    }
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("ground"))
                jumpCounting=0;
        }

    }

}
