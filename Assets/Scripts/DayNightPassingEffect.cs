using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightPassingEffect : MonoBehaviour
{   [Header("The color We Want our Background ToStart With")]
    [Tooltip("final colour by default is enviroment/backround colour so you only need to set accordingly")]
    public Color StartingColor;
    private Color finalColor;

    private Camera mainSceneCamera;
    [Header("Day Cycle")]
    [Tooltip("self explenatory")]
    public float timeToCompletCycle;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        mainSceneCamera = GetComponent<Camera>();
        finalColor = mainSceneCamera.backgroundColor;
    }

    // Update is called once per frame
    void Update()
    {
        float dayTime;
        timer += Time.deltaTime;
        dayTime = Mathf.PingPong(timer / timeToCompletCycle,1 );
        colorManager(dayTime);
 
    }
    private void colorManager(float RateOfChange)
    {
        Color backgroundColor = finalColor;
        backgroundColor = Color.LerpUnclamped(StartingColor, finalColor, RateOfChange);
        mainSceneCamera.backgroundColor = backgroundColor;
    }
   
}
