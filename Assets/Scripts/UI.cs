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
    public GameObject rStartingInputFieldObject;
    public TMP_InputField rStartingInputField;
    public GameObject gStartingInputFieldObject;
    public TMP_InputField gStartingInputField;
    public GameObject bStartingInputFieldObject;
    public TMP_InputField bStartingInputField;
    public TMP_InputField rEndingInputField;
    public TMP_InputField gEndingInputField;
    public TMP_InputField bEndingInputField;

    public TMP_InputField waitForSecondsInputField;

    public Toggle destroy1;
    public Toggle destroy2;
    public Toggle generate;
    public Toggle capsuleToggle;
    public GameObject advancedOptions;


    private void Awake()
    {
        //Debug.Log(inputFieldObject.GetComponent<TMP_InputField>());
        blockInputField = blockInputFieldObject.GetComponent<TMP_InputField>();
        branchInputField = branchInputFieldObject.GetComponent<TMP_InputField>();
        rStartingInputField = rStartingInputFieldObject.GetComponent<TMP_InputField>();
        gStartingInputField = gStartingInputFieldObject.GetComponent<TMP_InputField>();
        bStartingInputField = bStartingInputFieldObject.GetComponent<TMP_InputField>();
    }


    void Update()
    {
        CanvasGroup canvasGroup = Panel.GetComponent<CanvasGroup>();
        CanvasGroup canvasGroupAdvanced = advancedOptions.GetComponent<CanvasGroup>();


        if (Input.GetKeyDown("q"))
        {
            if (Panel.active)
            {
                Panel.SetActive(false);
            }
            else
            {
                Panel.SetActive(true);
            }
        }
        else
        {



            canvasGroup.alpha = 0.1f;
            canvasGroupAdvanced.alpha = 0.1f;
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            canvasGroup.alpha = 1f;
            canvasGroupAdvanced.alpha = 1f;
            TreeConstructor constructor = theConstructor.GetComponent<TreeConstructor>();
            constructor.branchProbability = (int)branchProbabilitySlider.value;
            branchInputField.text = constructor.branchProbability.ToString();

            constructor.BlocksLeft = (int)blockSlider.value;
            blockInputField.text = constructor.BlocksLeft.ToString();
        }

        if (Input.GetKeyDown("r"))
        {
            if (advancedOptions.active)
            {
                advancedOptions.SetActive(false);
            }
            else
            {
                advancedOptions.SetActive(true);
            }
        }

        if (Input.GetKeyDown("f"))
        {
            GameObject[] blocks = GameObject.FindGameObjectsWithTag("block");
            for (int i = 0; i < blocks.Length; i++)
            {
                Destroy(blocks[i]);
            }
        }

    }
    public void branchOnValueChanged()
    {
        if (branchInputField.text == "")
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
        constructor1.branchProbability = (int)blockSlider.value;
        constructor1.branchCount = 0;
        constructor1.averageBranchPerTree = 0;
        constructor1.totalTrees = 0;
        constructor1.totalBranches = 0;
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

        constructor1.branchCount = 0;
        constructor1.averageBranchPerTree = 0;
        constructor1.totalTrees = 0;
        constructor1.totalBranches = 0;
    }

    public void autoDestroyTree1()
    {
        TreeConstructor constructor1 = theConstructor.GetComponent<TreeConstructor>();

        // Have it wait before destroying everything
        if (destroy1.isOn)
        {
            GameObject[] blocks = GameObject.FindGameObjectsWithTag("block");
            for (int i = 0; i < blocks.Length; i++)
            {
                Destroy(blocks[i]);
            }
            constructor1.DestroyTime = 3;

        }
        else
        {
            constructor1.DestroyTime = 0;
        }
    }

    public void autoDestroyTree2()
    {
        TreeConstructor constructor1 = theConstructor.GetComponent<TreeConstructor>();
        if (destroy2.isOn)
        {
            constructor1.autoDestroy2 = true;
            constructor1.DestroyTime = 0;

        }
        else
        {
            constructor1.autoDestroy2 = false;

        }
    }

    public void autoGenerateTrees()
    {
        TreeConstructor constructor1 = theConstructor.GetComponent<TreeConstructor>();
        if (generate.isOn)
        {
            constructor1.autoGenerateTrees = true;
        }
        else
        {
            constructor1.autoGenerateTrees = false;
        }
    }

    public void RGBOnValueChanged()
    {

        if (rStartingInputField.text == "")
        {
            rStartingInputField.text = "0";
        }
        if (int.Parse(rStartingInputField.text) > 255)
        {
            rStartingInputField.text = "255";
        }
        else if (int.Parse(rStartingInputField.text) < 0)
        {
            rStartingInputField.text = "0";
        }


        if (gStartingInputField.text == "")
        {
            gStartingInputField.text = "0";
        }
        if (int.Parse(gStartingInputField.text) > 255)
        {
            gStartingInputField.text = "255";
        }
        else if (int.Parse(gStartingInputField.text) < 0)
        {
            gStartingInputField.text = "0";
        }


        if (bStartingInputField.text == "")
        {
            bStartingInputField.text = "0";
        }
        if (int.Parse(bStartingInputField.text) > 255)
        {
            bStartingInputField.text = "255";
        }
        else if (int.Parse(bStartingInputField.text) < 0)
        {
            bStartingInputField.text = "0";
        }

        TreeConstructor constructor1 = theConstructor.GetComponent<TreeConstructor>();
        constructor1.startingR = int.Parse(rStartingInputField.text);
        constructor1.startingG = int.Parse(gStartingInputField.text);
        constructor1.startingB = int.Parse(bStartingInputField.text);

    }

    public void RGBOnValueChangedEnding()
    {

        if (rEndingInputField.text == "")
        {
            rEndingInputField.text = "0";
        }
        if (int.Parse(rEndingInputField.text) > 255)
        {
            rEndingInputField.text = "255";
        }
        else if (int.Parse(rEndingInputField.text) < 0)
        {
            rEndingInputField.text = "0";
        }


        if (gEndingInputField.text == "")
        {
            gEndingInputField.text = "0";
        }
        if (int.Parse(gEndingInputField.text) > 255)
        {
            gEndingInputField.text = "255";
        }
        else if (int.Parse(gEndingInputField.text) < 0)
        {
            gEndingInputField.text = "0";
        }


        if (bEndingInputField.text == "")
        {
            bEndingInputField.text = "0";
        }
        if (int.Parse(bEndingInputField.text) > 255)
        {
            bEndingInputField.text = "255";
        }
        else if (int.Parse(bEndingInputField.text) < 0)
        {
            bEndingInputField.text = "0";
        }

        TreeConstructor constructor1 = theConstructor.GetComponent<TreeConstructor>();
        constructor1.startingR = int.Parse(rStartingInputField.text);
        constructor1.startingG = int.Parse(gStartingInputField.text);
        constructor1.startingB = int.Parse(bStartingInputField.text);
        constructor1.endingR = int.Parse(rEndingInputField.text);
        constructor1.endingG = int.Parse(gEndingInputField.text);
        constructor1.endingB = int.Parse(bEndingInputField.text);

    }

    public void Delay()
    {
        
        TreeConstructor constructor1 = theConstructor.GetComponent<TreeConstructor>();

        constructor1.waitForSeconds = float.Parse(waitForSecondsInputField.text);
        Debug.Log(float.Parse(waitForSecondsInputField.text));
            
    }

    public void useCapsules()
    {
        TreeConstructor constructor1 = theConstructor.GetComponent<TreeConstructor>();

        if (capsuleToggle.isOn)
        {
            constructor1.useCapsules = true;
        }
        else
        {
            constructor1.useCapsules = false;
        }
        
    }
    


}