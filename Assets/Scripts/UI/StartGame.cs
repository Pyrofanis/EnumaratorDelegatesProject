using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private PlayerControlls inputs;
    private Spawner spawner;
    private Animator animator;

    [Header("Materials of wanted Components")]
    [Tooltip("Drop the instances not the asset materials")]
    [Min(1)]
    public Material[] effectMaterials;
    private CanvasGroup canvasGroup;

    [SerializeField]
    private bool pressed;
    private void Awake()
    {
        inputs = new PlayerControlls();
        spawner = GameObject.FindObjectOfType<Spawner>();
        animator = GetComponentInParent<Animator>();
        inputs.Enable();

    }
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        pressed = false;//tha epireasti apo to animation toy animator
        inputs.MainControlls.UiButton.performed += _ => ButtonPressed();
    }
    private void Update()
    {
        if (pressed)
        {
            EffectMaterialsChangeAlpha();
        }
    }
    private void OnDisable()
    {
        spawner.enabled = true;
        inputs.MainControlls.UiButton.performed -= _ => ButtonPressed();
    }
    void ButtonPressed()
    {
        animator.SetTrigger("Start");
    }
    bool AnimationFinished()
    {
        return animator.GetCurrentAnimatorStateInfo(0).length <
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime
            && !animator.IsInTransition(0);
    }
    private void EffectMaterialsChangeAlpha()
    {
        foreach (Material mat in effectMaterials)
        {
            mat.SetFloat("_Alpha", canvasGroup.alpha);
        }
    }
}
