using UnityEngine;

public class Enemy1 : Enemy
{
    [SerializeField]
    private int HPpoint = 1;


    private void Awake()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HP = HPpoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
