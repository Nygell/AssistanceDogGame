using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchGameEventsManager
{
    public delegate void StartGame();

    public static event StartGame Started;
    void Start()
    {
        
    }

    public static void StartGameMethod()
    {
        Started?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
