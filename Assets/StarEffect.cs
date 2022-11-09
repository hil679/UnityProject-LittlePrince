using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarEffectManger : MonoBehaviour
{
    public ParticleSystem m_System; 
    ParticleSystem.Particle[] m_Particles; 
    // Start is called before the first frame update
    void Start()
    {
        //m_System = GetComponent<ParticleSystem>();
        m_Particles = new ParticleSystem.Particle[m_System.main.maxParticles];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate() {
        int numParticlesAlive = m_System.GetParticles(m_Particles);
        Debug.Log("Particle count "+numParticlesAlive);
    }
}
