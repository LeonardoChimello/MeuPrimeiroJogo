using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public int speed = 5;
    private int count;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI final;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    private void OnMove(InputValue movementValue)
    {

        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;


    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        SetCount();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("pickups"))
        {
        count++;
        other.gameObject.SetActive(false);
        }
        if(count >= 6)
        {
            final.text = "Parábens você ganhou!";
        }
    }

    private void SetCount()
    {
        if (count < 6)
        countText.text ="Coletados: " +count.ToString();
        else 
        countText.text ="";
    }
}
