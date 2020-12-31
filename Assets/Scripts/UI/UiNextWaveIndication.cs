using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiNextWaveIndication : MonoBehaviour
{
    private Text waveText;
    // Start is called before the first frame update
    void Start()
    {
        waveText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        IndicateWhenNewWaveStarts();
    }
    private void IndicateWhenNewWaveStarts()
    {
        if (Spawner.timeTillNextWave != 0)
        {
            if (Spawner._TimeToIndicateAtText >=0.5f)
            {
                waveText.text = "Next wave starts in " + Spawner._TimeToIndicateAtText.ToString("0");

            }
            else
            {
                waveText.text = "Fight !!!";
            }
        }
        else
        {
            waveText.text = "";
        }
    }
}
