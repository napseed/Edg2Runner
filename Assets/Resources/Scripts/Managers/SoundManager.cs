using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Sonity;
public class SoundManager : MonoBehaviour
{
    // 싱글턴
    private static SoundManager instance;

    // get하는 프로퍼티
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<SoundManager>();
                if (instance == null)
                {
                    GameObject player = new GameObject(typeof(SoundManager).Name);
                    instance = player.AddComponent<SoundManager>();

                    DontDestroyOnLoad(player);
                }
            }
            return instance;
        }
    }

    [SerializeField]
    private SoundEvent[] bgmArr;
    [SerializeField]
    private SoundEvent[] sfxArr;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            Debug.Log(gameObject.name + "destroyed");
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("SoundManager called on " + gameObject.name);
        }

        // 초기화(로딩)
        LoadSE();
    }

    // 리소스 폴더 내부의 SE를 로드
    void LoadSE()
    {
        bgmArr = Resources.LoadAll<SoundEvent>("Music/BGM");
        sfxArr = Resources.LoadAll<SoundEvent>("Music/SFX");
    }
    
    // 다양한 오버로딩을 만들어놓자
    public void PlayBGM(SoundEvent soev)
    {
        foreach (SoundEvent bgm in bgmArr)
        {
            if (bgm == soev)
            {
                bgm.PlayMusic();
            }
        }
    }

    public void PlayBGM(string name)
    {
        foreach (SoundEvent se in bgmArr)
        {
            if (se.name == name)
                se.PlayMusic();
        }
    }

    public void PlaySFX(SoundEvent soev)
    {
        foreach (SoundEvent sfx in sfxArr)
        {
            if (sfx == soev)
            {
                sfx.Play(transform);
            }
        }
    }

    public void PlaySFX(string name)
    {
        foreach (SoundEvent se in sfxArr)
        {
            if (se.name == name)
                se.Play(transform);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
