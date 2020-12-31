using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CurrentCompletedCycleIndicator : MonoBehaviour
{
    private Text completedCyclesText;
    // Start is called before the first frame update
    void Start()
    {
        completedCyclesText = GetComponent<Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        CheckNShow(); 
    }
    private void CheckNShow()
    {
        if (Spawner.completedCycles != 0)
        {
            completedCyclesText.text = "Completed Cycles: " + Spawner.completedCycles;
        }
        else
        {
            completedCyclesText.text = "";
        }
    }
}
