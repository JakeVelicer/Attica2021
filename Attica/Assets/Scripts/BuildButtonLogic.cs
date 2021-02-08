using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildButtonLogic : MonoBehaviour
{
    public Button buildButton;
    public TextMeshProUGUI buildButtonText;
    public GameObject buildObject;
    public GameObject objectIcon;
    public MousePicker mousePicker;
    private BaseUnit buildObjectScript;

    private void Awake()
    {
        buildObjectScript = buildObject.GetComponent<BaseUnit>();
        buildButtonText.text = buildObjectScript.cost.ToString();
    }

    public void ButtonBuildObject()
    {
        mousePicker.PickObject(buildObject, objectIcon);
    }

    public BaseUnit GetBuildObjectScript()
    {
        return buildObjectScript;
    }
}
