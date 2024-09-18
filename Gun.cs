using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    private CharacterInput controls;
    public float damage = 10f, range = 100f;
    public Camera fpsCam;

    private void Awake()
    {
        controls = new CharacterInput();
    }

    private void OnEnable()
    {
        controls.Enable();    
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        if(controls.Player.Shoot.triggered)
        {
            shoot();
        }
    }

    void shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target enemy = hit.transform.GetComponent<Target>();

            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
