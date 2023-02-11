using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    [SerializeField] InputField _name, _phone, _age, _email;
    [SerializeField] public string playerName, email, playerPhone, playerAge;

    public void SignUp()
    {
        PlayerPrefs.SetString("name", _name.text);
        PlayerPrefs.SetString ("email", _email.text);
        PlayerPrefs.SetString ("phone", _phone.text);
        PlayerPrefs.SetString ("age", _age.text);
    }
}
