using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGame : MonoBehaviour
{
    private PlayerControlls inputs;
    private void Awake()
    {
        inputs = new PlayerControlls();
        inputs.Enable();
    }
    // Start is called before the first frame update
    void Start()
    {
        inputs.MainControlls.EscapeExtGame.performed +=_=> QuitExitGame();
    }
    void QuitExitGame()
    {
        Application.Quit();
    }
}
