using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FileUserInput : MonoBehaviour
{
    [SerializeField] InputField nombreInput;
    [SerializeField] InputField emailInput;
    [SerializeField] InputField fechaNacimientoInput;
    [SerializeField] InputField telefonoInput;
    [SerializeField] string filename;
    List<FileUserEntry> entries = new List<FileUserEntry>();
    int contador = 0;
    public static FileUserInput Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        entries = FileUserJson.ReadListFromJSON<FileUserEntry>(filename);
        contador = PlayerPrefs.GetInt("nContador");
    }

    public void AddNameToList()
    {
        string fecha = System.DateTime.Now.ToString("dd/MM/yy hh:mm");
        entries.Add(new(contador, nombreInput.text, emailInput.text,
            fechaNacimientoInput.text, telefonoInput.text, fecha));
        nombreInput.text = "";
        emailInput.text = "";
        fechaNacimientoInput.text = "";
        telefonoInput.text = "";
        contador++;
        PlayerPrefs.SetInt("nContador", contador);
        PlayerPrefs.Save();
        FileUserJson.SaveToJSON(entries, filename);
      //  EmailInfo.Instance.textACero();
    }


    public void AddNameToListW()
    {
        string fecha = System.DateTime.Now.ToString("dd/MM/yy hh:mm");
        entries.Add(new(contador, nombreInput.text, emailInput.text,
            fechaNacimientoInput.text, telefonoInput.text, fecha));
        nombreInput.text = "";
        emailInput.text = "";
        fechaNacimientoInput.text = "";
        telefonoInput.text = "";
        contador++;
        PlayerPrefs.SetInt("nContador", contador);
        PlayerPrefs.Save();
        FileUserJson.SaveToJSON(entries, filename);
        EmailInfo.Instance.textACero();
        StartCoroutine(IrMenu());
    }
    private IEnumerator IrMenu()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Menu");
    }

   
}