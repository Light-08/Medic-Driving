using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 noMedicineColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 hasMedicineColor = new Color32(1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.5f;

    bool hasMedicine = false;

    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other){
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Medicine" && !hasMedicine){
            hasMedicine = true;
            Debug.Log("Medicine Picked Up.");
            spriteRenderer.color = hasMedicineColor;
            Destroy(other.gameObject, destroyDelay);
        }
        
        if(other.tag == "Patient" && hasMedicine){
            Debug.Log("Medicine Delivered.");
            hasMedicine = false;
            spriteRenderer.color = noMedicineColor;
            Destroy(other.gameObject, destroyDelay);
        }
    }
}
