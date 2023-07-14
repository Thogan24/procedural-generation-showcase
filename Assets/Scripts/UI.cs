using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{

    public Slider branchProbabilitySlider;
    public TextMeshProUGUI branchProbabilityText;
    public GameObject theConstructor;
    
    void Start()
    {
        
    }

    void Update()
    {
        TreeConstructor constructor = theConstructor.GetComponent<TreeConstructor>();
        constructor.branchProbability = (int) branchProbabilitySlider.value;
        branchProbabilityText.text = constructor.branchProbability.ToString();
    }
}
