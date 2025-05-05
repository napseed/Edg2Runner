using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixer audioMixer;

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
