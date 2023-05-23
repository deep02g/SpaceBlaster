using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   
    private InputManager inputManager = null;
    private Animator animator;
    private AudioSource audioSource;

   
    public GameObject bulletPrefab;
    public Transform firePoint;

    private float cooldownTimer = Mathf.Infinity;
    public bool isPlayerControlled = false;
    public float fireRate = 0.05f;


    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        SetupInput();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void SetupInput()
    {
        if (isPlayerControlled)
        {
            if (inputManager == null)
            {
                inputManager = InputManager.instance;
            }
            if (inputManager == null)
            {
                Debug.LogError("Player Shooting Controller can not find an InputManager in the scene, there needs to be one in the " +
                    "scene for it to run");
            }
        }
    }

    void ProcessInput()
    {
        if (isPlayerControlled)
        {
            if ((inputManager.firePressed || inputManager.fireHeld))
            {
                
                
                Fire();
                
            }
            //cooldownTimer += Time.timeSinceLevelLoad;
           
        }
    }

    private void Fire()
    {
        //animator.SetTrigger("fire");
        if((Time.timeSinceLevelLoad - cooldownTimer) > fireRate)
        {
            animator.SetTrigger("fire");
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation, null);
            audioSource.Play();
        }
        cooldownTimer = Time.timeSinceLevelLoad;

    }

}
