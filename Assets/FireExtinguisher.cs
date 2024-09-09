using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : GrabAbleObjScript
{
    public ParticleSystem powderParticle;

    bool isSpaying;

    public AudioSource sprayStartSource;
    public AudioSource sprayLoopSource;
    public AudioSource sprayEndSource;
    
    bool wasKeyPressed;

    private void Start()
    {
        powderParticle.Stop();
    }

    private void Update()
    {
        bool isKeyPressed = Input.GetKey(KeyCode.LeftControl);

        if (isKeyPressed && !wasKeyPressed)
        {
            // Ű�� ������ ������ ��� (����)
            sprayStartSource.Play();
        }
        else if (!isKeyPressed && wasKeyPressed)
        {
            // Ű�� ������ ��� (����)
            if (sprayLoopSource.isPlaying)
                sprayLoopSource.Stop();
            if(sprayStartSource.isPlaying)
                sprayStartSource.Stop();

            sprayEndSource.Play();
        }
        else if(isKeyPressed && wasKeyPressed)
        {
            if (sprayStartSource.isPlaying)
                return;
            else if(!sprayLoopSource.isPlaying)
                sprayLoopSource.Play();

        }
        // ���ӵ� ��쿡�� ������ ó���� �ʿ� ���� (loopSound�� �̹� ��� ����)

        // ���� �������� Ű ���¸� ���� �����ӿ����� ���� ���·� ����
        wasKeyPressed = isKeyPressed;
    }

    public void SprayPowder()
    {
        powderParticle.Play();
        isSpaying = true;
    }

    public void StopSprayPowder()
    {
        powderParticle.Stop(withChildren: true, stopBehavior: ParticleSystemStopBehavior.StopEmitting);
    }

}
