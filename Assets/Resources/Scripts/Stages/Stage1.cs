using Sonity;
using UnityEngine;

public class Stage1 : MonoBehaviour
{
    SoundManager soundManager;
    public SoundEvent stage1BGM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundManager = SoundManager.Instance;
        PlayStage1();
    }

    public void PlayStage1()
    {
        Debug.Log("스테이지1 bgm 재생");
        soundManager.PlayBGM(stage1BGM);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
