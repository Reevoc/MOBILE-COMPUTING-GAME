using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerNameController : MonoBehaviour
{
    /* significato risposte dal server:
     * 0=valido
     * 1=già preso
     * 2=non valido

     */

    //* TODO Login in base a id del dispositivo, risposta con il nome e check del nome (l'ultimo inserito).
    /* Se il nome è diverso da quello memorizzato su dispositivo allora viene memorizzato il nuovo nome ed eliminato il vecchio */

    // Sul server. Quando viene mostrata la classifica mostrare solo l'ultimo nome di quelli che hanno lo stesso deviceId

    public GameObject namePanel;

    public GameObject nameErrorPanel;

    public TextMeshProUGUI errorText;

    public TMP_InputField nameField;

    public GameObject messagePanel;
    public TextMeshProUGUI messageTitle;
    public TextMeshProUGUI messageDetails;

    private IEnumerator insertPlayerName(string name)
    {
        string url = "http://sharebox.altervista.org/new_player.php";
        WWWForm form = new WWWForm();
        form.AddField("deviceId", SystemInfo.deviceUniqueIdentifier);
        form.AddField("name", name);

        //Debug.Log("Sending id and name " + SystemInfo.deviceUniqueIdentifier + " " + name);

        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("Web error");
        }

        string response = www.downloadHandler.text;
        this.convalidate(name,response);
    }

    private void convalidate(string name,string numero)
    {
        string daMostrare = "";

        if (numero == "0")
        {
            // configurare nome localmente tra le playerprefs
            PlayerPrefs.SetString("username",name);
            this.namePanel.SetActive(false);
            this.messageTitle.text = "Login";
            this.messageDetails.text = "Name set successfully. Welcome " + name;
            this.messagePanel.SetActive(true);
            this.messagePanel.GetComponent<MessagePanelController>().dismissPanel();
            //Debug.Log("Nome settato correttamente su " + name);
        }
        else
        {
            if (numero == "1")
            {
                //Debug.Log("Nome già preso");
                errorText.text = "Name already exists. Please, choose another";
            }
            else if (numero == "2")
            {
                //Debug.Log("nome non valido. Scegline uno nuovo");
                errorText.text = "Name not valid. Please, choose another";
            } else
            {
                errorText.text = "Unknown network error. Please retry later";
            }
            //Debug.Log(numero);
            nameErrorPanel.SetActive(true);
        }
    }

    // Metodi facade

    public void confirmNameInsertion()
    {
        string choosenName = this.nameField.text;
        StartCoroutine(this.insertPlayerName(choosenName));
    }

    public void dismissNamePanelDialog()
    {
        this.namePanel.SetActive(false);
    }

    public void dismissErrorDialog()
    {
        this.nameErrorPanel.SetActive(false);
    }

}
