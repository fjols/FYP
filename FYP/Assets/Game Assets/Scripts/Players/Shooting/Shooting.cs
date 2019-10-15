using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public string m_sAButton;
    public GameObject m_bullet;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown(m_sAButton))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(m_bullet, firePoint.position, firePoint.rotation);
    }
}
