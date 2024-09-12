using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.MultiplayerModels;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PlayFab.CloudScriptModels;

public class LoginPagePlayFab : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI MessageText;

    [Header("Login")]
    [SerializeField] TMP_InputField EmailLoginInput;
    [SerializeField] TMP_InputField PasswordLoginInput;
    [SerializeField] GameObject LoginPage;

    [Header("Register")]
    [SerializeField] TMP_InputField UsernameRegisterInput;
    [SerializeField] TMP_InputField EmailRegisterInput;
    [SerializeField] TMP_InputField PasswordRegisterInput;
    [SerializeField] GameObject RegisterPage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region ButtomFunctions
    public void RegisterUser()
    {
        var request = new RegisterPlayFabUserRequest
        {
            DisplayName = UsernameRegisterInput.text,
            Email = EmailRegisterInput.text,
            Password = PasswordRegisterInput.text,

            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnregisterSucces, OnError);
    }

    private void OnError(PlayFabError Error)
    {
        MessageText.text = Error.ErrorMessage;
        Debug.Log(Error.GenerateErrorReport());
    }

    private void OnregisterSucces(RegisterPlayFabUserResult Result)
    {
        MessageText.text = "New account is created";
        OpenLoginPage();
    }
    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = EmailLoginInput.text,
            Password = PasswordLoginInput.text,

            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }

        };
        
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSucces, OnError);
    }

    private void OnLoginSucces(LoginResult result)
    {
        string name = null;
        name = result.InfoResultPayload.PlayerProfile.DisplayName;
        PlayerPrefs.SetString("MyStringKey", name);
        PlayerPrefs.Save();

       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }

    public void OpenLoginPage()
    {
        LoginPage.SetActive(true);
        RegisterPage.SetActive(false);
    }
    public void OpenRegisterPage()
    {
        LoginPage.SetActive(false);
        RegisterPage.SetActive(true);
    }
    #endregion
    
}
