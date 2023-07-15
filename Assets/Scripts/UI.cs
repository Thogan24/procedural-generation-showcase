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
    public GameObject inputFieldObject;
    public InputField inputField;


    private void Awake()
    {
        inputField = inputFieldObject.GetComponent<InputField>();
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
            branchProbabilityText.text = constructor.branchProbability.ToString();

            constructor.BlocksLeft = (int) blockSlider.value;
            blockText.text = constructor.BlocksLeft.ToString();
        }
        
    }

    public void blockInputButton()
    {
        //blockTextObject.SetActive(false);
        //blockInputObject.SetActive(true);
    }

    public void onValueChanged()
    {
        Debug.Log("Bruhington");
        //InputField inputField = inputFieldObject.GetComponent<InputField>();
        blockSlider.value = int.Parse(inputField.text); 
        TreeConstructor constructor1 = theConstructor.GetComponent<TreeConstructor>();
        constructor1.BlocksLeft = (int) blockSlider.value;
    }
}
