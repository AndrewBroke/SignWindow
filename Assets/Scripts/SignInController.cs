using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignInController : MonoBehaviour
{
    [SerializeField] private FormController _formController;
    [SerializeField] private InputField _input;
    [SerializeField] private Text _textMessage;

    private int _tryCount;

    // Start is called before the first frame update
    void Start()
    {
        _tryCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SignInClick()
    {
        string inputPassword = _input.text;
        if (!PlayerPrefs.HasKey("Password")) throw new Exception("PasswordDoesntExist");

        string savedPassword = PlayerPrefs.GetString("Password");
        if(inputPassword == savedPassword && _tryCount >= 1)
        {
            LoadMainScene();
        }
        else
        {
            PrintError();
        }
    }

    public void ResetClick()
    {
        PlayerPrefs.DeleteKey("Password");
        _formController.CheckPasswordInCache();
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }

    private void PrintError()
    {
        _tryCount--;
        if(_tryCount <= 0)
        {
            _textMessage.text = "Доступ заблокирован";
            Application.Quit();
            return;
        }
        _textMessage.text = "Пароль неверный. Осталось попыток: " + _tryCount.ToString();
    }
}
