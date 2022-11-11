using ESN;
using System.Collections;
using System.ComponentModel;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EmailInfo : MonoBehaviour
{
    string SMTPAddress = "smtp.gmail.com";
    int SMTPPort = 587;

    string From = "************@gmail.com";
    string Password = "****************";


    bool EnableSSL = true;
    bool UseDefaultCredentials = false;
    public Text txtInfo;
    public static EmailInfo Instance;
    EMailSender mailSender;




    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void OnEnable()
    {
        if (EmailInfo.Instance != null && EmailInfo.Instance != gameObject.GetComponent<EmailInfo>())
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            EmailInfo.Instance = gameObject.GetComponent<EmailInfo>();
        }

        mailSender = new EMailSender(From, Password, SMTPAddress, SMTPPort, EnableSSL, UseDefaultCredentials);
    }


    public void SendMailParticipante(string from, string fromName, string to, string subject, string message, string attachment)
    {
        mailSender.SendMailParticipante(from, fromName, to, subject, message, onAsyncComplete, attachment);
    }

    void onAsyncComplete(object sender, AsyncCompletedEventArgs completedEventArgs)
    {

        if (completedEventArgs.Error != null)
        {
            StartCoroutine(ShowInfo("Error"));
            Debug.LogError(completedEventArgs.Error.Message);
            Debug.LogWarning(" Error. Reintente.");
            return;
        }

        if (completedEventArgs.Cancelled)
        {
            StartCoroutine(ShowInfo("Envio cancelado"));
            Debug.LogWarning("Envio cancelado.");
            return;
        }

        StartCoroutine(ShowInfo("Email enviado exitosamente."));
        Debug.Log("Email enviado exitosamente.");
     
        SmtpClient sndr = (SmtpClient)sender;
        sndr.SendCompleted -= onAsyncComplete;
       // StartCoroutine(CargarDatosJson());
    }

    IEnumerator ShowInfo(string msg)
    {
        txtInfo.text = msg;
        yield return new WaitForSeconds(20f);
        txtInfo.text = "";
    }

    IEnumerator CargarDatosJson()
    {
        FileUserInput.Instance.AddNameToList();
        yield return new WaitForSeconds(3f);
        txtInfo.text = "";
        SceneManager.LoadScene("Menu");
    }


    public void textACero()
    {
        txtInfo.text = "";
    }
}