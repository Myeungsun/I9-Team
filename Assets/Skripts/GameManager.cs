using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject meteor;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeMeteor", 0f, 1f);
        MakeMeteor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeMeteor()
    {
        Instantiate(meteor);
    }
}
