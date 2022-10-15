using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 30f;
    [SerializeField] float slowSpeed = 20f;
    [SerializeField] float boostSpeed = 40f;
    [SerializeField] float destroyDelay = 0.5f;

    void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
        Debug.Log("You are now slowed down!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Boost"){
            moveSpeed = boostSpeed;
            Debug.Log("You are now boosted!");
            Destroy(other.gameObject, destroyDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
