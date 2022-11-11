using System;
using UnityEngine;
using UnityEngine.UI;

public class EmailUI : MonoBehaviour
{
    string From = "catamarca";    
    string Name = "CATAMARCA";       
    string Subject = "Gracias por visitarnos;   
    string Message = "Te estaremos esperando!";   

    public InputField Email;
    public string AttachmentFilename = "Screenshot.jpg"; 

    public void SendMailParticipante()
    {
        EmailInfo.Instance.SendMailParticipante(
            From,
            Name,
            Email.text,
            Subject,
            Message,
            Application.temporaryCachePath + "/" + AttachmentFilename
             );
    }



    public void Quit()
    {
        Application.Quit();
    }

}