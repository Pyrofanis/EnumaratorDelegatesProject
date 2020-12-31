using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Players_Health : MonoBehaviour
{
    private PlayerStats playerStats;
    private Slider healthSlider;
    private void Awake()
    {
        playerStats = GameObject.FindObjectOfType<PlayerStats>();
        healthSlider = GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = playerStats.playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = playerStats.playerHealth;
    }
}
