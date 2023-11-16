using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float maxXPosition = 3.5f;
    public float minXPosition = -3.5f;

    [SerializeField] GameObject[] ammos;
    
    private void Update()
    { 
        Movement();
        ProcessFiring();
    }

    private void Movement()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }
        
        inputVector = inputVector.normalized;
        
        

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        Vector3 newPosition=  transform.position + (moveDir * Time.deltaTime * speed);

        newPosition.x = Mathf.Clamp(newPosition.x, minXPosition, maxXPosition);
        transform.position = newPosition;
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetBulletActive(true);
        }
        else
        {
            SetBulletActive(false);
        }
    }

    void SetBulletActive(bool isActive)
    {
        foreach (GameObject ammo in ammos)
        {
            var emissionModule = ammo.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
