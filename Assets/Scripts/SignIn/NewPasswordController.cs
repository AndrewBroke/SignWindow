using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPasswordController : MonoBehaviour
{
    [SerializeField] private FormController _formController;
    [SerializeField] private InputField _input;
    [SerializeField] private Button _saveButton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check the input if it is empty
        string inputText = _input.text;
        if (inputText == "")
        {
            _saveButton.interactable = false;
        }
        else
        {
            _saveButton.interactable = true;
        }
    }

    public void SaveClick()
    {
        PlayerPrefs.SetString("Password", _input.text);
        _input.text = "";
        _formController.CheckPasswordInCache();
    }
}
