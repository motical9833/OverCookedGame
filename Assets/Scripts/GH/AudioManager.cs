using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSoure;
    Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        audioSoure = GetComponent<AudioSource>();

        if (!audioSoure)
        {
            Debug.Log("����� �ҽ��� �������� ����!!");
            return;
        }

        AudioClip[] clips = Resources.LoadAll<AudioClip>("Sound");

        for (int i = 0; i < clips.Length; i++)
        {
            audioClips.Add(clips[i].name, clips[i]);
        }
    }


    public AudioClip GetAudioClip(string name)
    {
        AudioClip clip = audioClips[name];

        if (!clip)
        {
            Debug.Log("�ش� ����� Ŭ���� �������� �ʽ��ϴ�.");
            return null;
        }
        return clip;
    }
}