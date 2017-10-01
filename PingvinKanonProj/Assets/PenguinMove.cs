using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinMove : MonoBehaviour
{

    bool m_Launched = false;
    bool m_Landed = false;

    public float m_FlySpeed;

    float m_DistanceToFly = 0.0f;

    void Start()
    {

    }

    void Update()
    {
        if (m_Launched)
        {
            transform.position += new Vector3(Time.deltaTime * m_FlySpeed, 0, 0);
            m_DistanceToFly -= Time.deltaTime * m_FlySpeed;
        }

        if(m_DistanceToFly <= 0)
        {
            m_Launched = false;
            m_Landed = true;
        }
    }

    public void Launch(float i_Distance)
    {
        m_Launched = true;
        m_DistanceToFly = i_Distance;
    }
}