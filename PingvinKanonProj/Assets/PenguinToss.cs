using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinToss : MonoBehaviour
{

    public GameObject m_Penguin;
    public float m_MaxFlyDistance;
    public float m_FlyDistance;

    bool m_TimerActive = false;

    public float m_TimeToFullCharge;
    float m_Time = 0.0f;

	void Start ()
    {

	}
	
	void Update ()
    {
        if(m_TimerActive)
        {
            m_Time += Time.deltaTime;
        }
		if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            m_TimerActive = true;
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {

            if (m_Time > m_TimeToFullCharge)
                m_Time = m_TimeToFullCharge;

            m_FlyDistance = (m_Time / m_TimeToFullCharge) * m_MaxFlyDistance;

            GameObject penguin = Instantiate(m_Penguin);
            penguin.transform.position = transform.position;
            penguin.SendMessage("Launch", m_FlyDistance);

            m_TimerActive = false;
            m_Time = 0.0f;
        }
	}
}
