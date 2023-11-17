using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float maxXPosition = 3.5f;
    public float minXPosition = -3.5f;
    [SerializeField] private ShootController shootController;

    private readonly List<Transform> _enemies = new();
    private bool _isShooting;

   // [SerializeField] GameObject[] ammos;
    
    private void Update()
    { 
        Movement();
        //ProcessFiring();
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
    
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag($"Enemy"))
        {
            if (!_enemies.Contains(other.transform))
                _enemies.Add(other.transform);

            AutoShoot();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag($"Enemy"))
        {
            _enemies.Remove(other.transform);
        }
    }

    private void AutoShoot()
    {
        IEnumerator Do()
        {
            while (_enemies.Count > 0)
            {
                var enemy = _enemies[0];
                var myTransform = transform;
                var position = myTransform.position;
                var direction = enemy.transform.position - position;
                direction.y = 0;
                direction = direction.normalized;
                shootController.Shoot(direction, position);
                _enemies.RemoveAt(0);
                yield return new WaitForSeconds(shootController.Delay);
            }

            _isShooting = false;
        }

        if (!_isShooting)
        {
            _isShooting = true;
            StartCoroutine(Do());
        }
    }

    /*void ProcessFiring()
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
    }*/
}
