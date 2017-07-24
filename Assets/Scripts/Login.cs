using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public bool createAccount = false;
    public bool forgotAccount = false;
    public string username = "";
    public string password = "";
    public string email = "";

    void OnGUI()
    {
        float scrW = Screen.width / 16f;
        float scrH = Screen.height / 9f;
        int i = 0;

        if (createAccount == false)
        {
            GUI.Box(new Rect(4 * scrW, 3f * scrH, 8 * scrW, 4f * scrH), "");

            GUI.Box(new Rect(5 * scrW, 4f * scrH, 2 * scrW, 0.5f * scrH), "Username");
            username = GUI.TextField(new Rect(7 * scrW, 4f * scrH, 2 * scrW, 0.5f * scrH), username, 15);
            GUI.Box(new Rect(5f * scrW, 4.5f * scrH, 2 * scrW, 0.5f * scrH), "Password");
            password = GUI.TextField(new Rect(7 * scrW, 4.5f * scrH, 2 * scrW, 0.5f * scrH), password, 15);
            if (GUI.Button(new Rect(9 * scrW, 4f * scrH, 2 * scrW, 1f * scrH), "Login"))
            {

            }
            // Create account
            if (GUI.Button(new Rect(5 * scrW, 5.5f * scrH, 6 * scrW, 1f * scrH), "Create Account"))
            {
                createAccount = true;
            }
        }
        else
        {
            GUI.Box(new Rect(4 * scrW, 3f * scrH, 8 * scrW, 4f * scrH), "");
            GUI.Box(new Rect(5 * scrW, 4f * scrH, 2 * scrW, 0.5f * scrH), "Create Username");
            username = GUI.TextField(new Rect(7 * scrW, 4f * scrH, 2 * scrW, 0.5f * scrH), username, 15);
            GUI.Box(new Rect(5 * scrW, 4.5f * scrH, 2 * scrW, 0.5f * scrH), "Email Address");
            email = GUI.TextField(new Rect(7 * scrW, 4.5f * scrH, 2 * scrW, 0.5f * scrH), email, 15);
            GUI.Box(new Rect(5f * scrW, 5f * scrH, 2 * scrW, 0.5f * scrH), "Create Password");
            password = GUI.TextField(new Rect(7 * scrW, 5f * scrH, 2 * scrW, 0.5f * scrH), password, 15);
            GUI.Box(new Rect(5f * scrW, 5.5f * scrH, 2 * scrW, 0.5f * scrH), "Confirm Password");
            password = GUI.TextField(new Rect(7 * scrW, 5.5f * scrH, 2 * scrW, 0.5f * scrH), password, 15);
            if (GUI.Button(new Rect(9f * scrW, 4f * scrH, 2 * scrW, 2f * scrH), "Enter"))
            {
                StartCoroutine(CreateUser(username, password, email));
            }
            if (GUI.Button(new Rect(4f * scrW, 6.5f * scrH, 1 * scrW, 0.5f * scrH), "Back"))
            {
                createAccount = false;
            }
        }

    }

    IEnumerator CreateUser(string userName, string passWord, string eMail)
    {
        string createUserURL = "http://localhost/unicorns_d/InsertUser.php";

        WWWForm userInfo = new WWWForm();
        userInfo.AddField("usernamePost", userName);
        userInfo.AddField("passwordPost", passWord);
        userInfo.AddField("emailPost", eMail);
        WWW www = new WWW(createUserURL, userInfo);

        yield return www;

        Debug.Log(www.text);
    }
}
