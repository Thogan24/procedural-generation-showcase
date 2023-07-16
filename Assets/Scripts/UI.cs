using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public GameObject Panel;
   // public GameObject blockTextObject;
    //public GameObject blockInputObject;
    public Slider branchProbabilitySlider;
    public TextMeshProUGUI branchProbabilityText;
    public Slider blockSlider;
    public TextMeshProUGUI blockText;
    public GameObject theConstructor;
    public GameObject blockInputFieldObject;
    public TMP_InputField blockInputField;
    public GameObject branchInputFieldObject;
    public TMP_InputField branchInputField;

    private void Awake()
    {
        //Debug.Log(inputFieldObject.GetComponent<TMP_InputField>());
        blockInputField = blockInputFieldObject.GetComponent<TMP_InputField>();
        branchInputField = branchInputFieldObject.GetComponent<TMP_InputField>();
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
            constructor.branchProbability = (int) branchProbabilitySlider.value;
            branchInputField.text = constructor.branchProbability.ToString();

            constructor.BlocksLeft = (int) blockSlider.value;
            blockInputField.text = constructor.BlocksLeft.ToString();
        }
        
    }

    public void blockInputButton()
    {
        //blockTextObject.SetActive(false);
        //blockInputObject.SetActive(true);
    }

    public void branchOnValueChanged()
    {
        if(branchInputField.text == "")
        {
            branchInputField.text = branchProbabilitySlider.minValue.ToString();
        }


        if (int.Parse(branchInputField.text) > branchProbabilitySlider.maxValue)
        {
            branchInputField.text = branchProbabilitySlider.maxValue.ToString();
        }
        else if (int.Parse(branchInputField.text) < branchProbabilitySlider.minValue)
        {
            branchInputField.text = branchProbabilitySlider.minValue.ToString();
        }
        branchProbabilitySlider.value = int.Parse(branchInputField.text); 
        TreeConstructor constructor1 = theConstructor.GetComponent<TreeConstructor>();
        constructor1.branchProbability = (int) blockSlider.value;
    }

    public void blockOnValueChanged()
    {

        if (int.Parse(blockInputField.text) > blockSlider.maxValue)
        {
            blockInputField.text = blockSlider.maxValue.ToString();
        }
        else if (int.Parse(blockInputField.text) < blockSlider.minValue)
        {
            blockInputField.text = blockSlider.minValue.ToString();
        }
        blockSlider.value = int.Parse(blockInputField.text);
        TreeConstructor constructor1 = theConstructor.GetComponent<TreeConstructor>();
        constructor1.BlocksLeft = (int)blockSlider.value;
    }
}
