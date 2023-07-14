using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public GameObject Panel;
    public Slider branchProbabilitySlider;
    public TextMeshProUGUI branchProbabilityText;
    public GameObject theConstructor;
    
    void Start()
    {
        
    }

    void Update()
    {
        CanvasGroup canvasGroup = Panel.GetComponent<CanvasGroup>();

        

        if (Input.GetKey("q"))
        {
            canvasGroup.alpha = 0f;
        }
        else
        {
            canvasGroup.alpha = 0.1f;
        }
        
        if (Input.GetKey(KeyCode.Tab))
        {
            canvasGroup.alpha = 1f;
            TreeConstructor constructor = theConstructor.GetComponent<TreeConstructor>();
            constructor.branchProbability = (int)branchProbabilitySlider.value;
            branchProbabilityText.text = constructor.branchProbability.ToString();
        }
        
    }
}
