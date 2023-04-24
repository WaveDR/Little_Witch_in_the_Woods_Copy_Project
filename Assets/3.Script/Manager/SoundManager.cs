using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance = null;

    // Start is called before the first frame update

    #region Singleton
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
    #endregion Singleton

    public AudioSource[] audio_Source_Effects;
    public AudioSource audioSourceBGM;

    public Sound[] sounds_Effect;
    public Sound[] sounds_BGM;
    public string[] play_Sound_Name;
    public bool isPlay = false;
    private void OnEnable()
    {

    }
    private void Start()
    {
        play_Sound_Name = new string[audio_Source_Effects.Length];
    }
    public void Play_Sound_Effect(string _Name)
    {
        for (int i = 0; i < sounds_Effect.Length; i++)
        {
            if (_Name == sounds_Effect[i].name)
            {
                for (int j = 0; j < audio_Source_Effects.Length; j++)
                {
                    if (!audio_Source_Effects[j].isPlaying)
                    {
                        play_Sound_Name[j] = sounds_Effect[i].name;

                        
                        audio_Source_Effects[j].clip = sounds_Effect[i].clip;
                        audio_Source_Effects[j].Play();
                        
                        return;
                    }
                }
                //Debug.Log("��� ���� AudttioSource�� ��� ���Դϴ�.");
                return;
            }
            //Debug.Log(_Name + "���尡 SoundManager�� ��ϵ��� �ʾҽ��ϴ�");
        }

    }
    public void Play_Sound_BGM(string _Name)
    {

        for (int i = 0; i < sounds_BGM.Length; i++)
        {
            if (_Name == sounds_BGM[i].name)
            {
                for (int j = 0; j < audio_Source_Effects.Length; j++)
                {
                    if (!audio_Source_Effects[j].isPlaying)
                    {
                        play_Sound_Name[j] = sounds_BGM[i].name;


                        audio_Source_Effects[j].clip = sounds_BGM[i].clip;
                        audio_Source_Effects[j].Play();

                        return;
                    }
                }
              //  Debug.Log("��� ���� AudttioSource�� ��� ���Դϴ�.");
                return;
            }
           // Debug.Log(_Name + "���尡 SoundManager�� ��ϵ��� �ʾҽ��ϴ�");
        }
    }
    public void Stop_All_Sound_Effect()
    {
        for (int i = 0; i < audio_Source_Effects.Length; i++)
        {
            audio_Source_Effects[i].Stop();
        }
    }

    public void Stop_Sound_Effect(string _Name)
    {
        for (int i = 0; i < audio_Source_Effects.Length; i++)
        {

            if (play_Sound_Name[i] == _Name)
            {
                audio_Source_Effects[i].Stop();

                return;
            }
        }
       // Debug.Log("��� ����" + _Name + "���尡 �����ϴ�.");
    }
}
