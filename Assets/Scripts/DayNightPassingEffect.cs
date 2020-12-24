using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightPassingEffect : MonoBehaviour
{   [Header("The color We Want our Background ToStart With")]
    [Tooltip("final colour by default is enviroment/backround colour so you only need to set accordingly")]
    public Color startingColorSky;
    private Color finalColorSky;

    private Camera mainSceneCamera;
    [Header("Material Of Cloud Particles")]
    [Tooltip("Drop The mat")]
    public Material CloudParticleMat;

    [Header("cloud  Colours")]
    [Tooltip("better set around the rgb values starting colour")]
    public Color StartingColorClouds;
    [Tooltip("better set around the rgb values its the final color")]
    public Color finalColorClouds;

    [Header("Day Cycle")]
    [Tooltip("self explenatory")]
    public float timeToCompletCycle;
    private float timer;



    // Start is called before the first frame update
    void Start()
    {
        mainSceneCamera = GetComponent<Camera>();
        finalColorSky = mainSceneCamera.backgroundColor;
    }

    // Update is called once per frame
    void Update()
    {
        float dayTime;
        timer += Time.deltaTime;
        dayTime = Mathf.PingPong(timer / timeToCompletCycle,1 );
        colorManager(dayTime, startingColorSky, finalColorSky,Camera.main);
        colorManager(dayTime, StartingColorClouds, finalColorClouds,null, CloudParticleMat);
 
    }
    private void colorManager(float RateOfChange, Color startingColour,Color finalColour,Camera camera=null,Material cloudMat=null)
    {
        Color backgroundColor = finalColour;
        backgroundColor = Color.LerpUnclamped(startingColour, finalColour, RateOfChange);
        if (camera != null)
        {
            camera.backgroundColor = backgroundColor;
        }
        if (cloudMat != null)
        {
            cloudMat.SetColor("_Color", backgroundColor);
        }
    }
   
}
