using UnityEngine;
using System;


[Serializable]
public class FileUserEntry
{
    public int contador;
    public string nombre;
    public string fechaNacimiento;
    public string email;
    public string telefono;
    public string hora;

    public FileUserEntry(int count, string name, string mail, string data, string cell, string saveTime)
    {
        contador = count;
        nombre = name;
        fechaNacimiento = data;
        email = mail;
        telefono = cell;
        hora = saveTime;

    }
}
