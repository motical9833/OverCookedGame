using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour
{
    AudioManager audioManager = null;
    AudioSource audioSource = null;

    void Start()
    {
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        audioSource = gameObject.GetComponent<AudioSource>();

        if (!audioSource || !audioManager)
        {
            Debug.Log("����� �Ŵ��� �Ǵ� ����� �ҽ��� ������Ʈ�� �������� �ʽ��ϴ�.");
            return;
        }
        audioSource.clip = audioManager.GetAudioClip("StartScreenMusic");
        audioSource.Play();
    }

    public void StartBGM(string name)
    {
        audioSource.clip = audioManager.GetAudioClip(name);
        audioSource.Play();
    }
}