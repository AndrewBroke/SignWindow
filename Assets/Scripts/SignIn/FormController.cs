using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormController : MonoBehaviour
{
    [SerializeField] private GameObject _signInForm;
    [SerializeField] private GameObject _newPasswordForm;

    // Start is called before the first frame update
    void Start()
    {
        CheckPasswordInCache();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckPasswordInCache()
    {
        if (PlayerPrefs.HasKey("Password"))
        {
            _newPasswordForm.SetActive(false);
            _signInForm.SetActive(true);
        }
        else
        {
            _newPasswordForm.SetActive(true);
            _signInForm.SetActive(false);
        }
    }
}
