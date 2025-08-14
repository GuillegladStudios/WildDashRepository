using UnityAtoms.BaseAtoms;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    private const string Puntaje_Mas_Altos = "Puntajes_Mas_Altos";

    private const string Volumen = "Volumen";

    public void SavePuntajeMasAlto(IntVariable puntos)
    {
        int puntajeMasAlto = PlayerPrefs.GetInt(Puntaje_Mas_Altos, 0); // Obtener el puntaje más alto guardado, por defecto es 0

        if (puntos.Value > puntajeMasAlto)
        {
            PlayerPrefs.SetInt(Puntaje_Mas_Altos, puntos.Value); // Guardar el nuevo puntaje más alto

            PlayerPrefs.Save(); // Asegurarse de que los cambios se guarden
        }
    }

    public int GetPuntajeMasAlto()
    {
        return PlayerPrefs.GetInt(Puntaje_Mas_Altos, 0); // Obtener el puntaje más alto guardado, por defecto es 0
    }

    public void SaveVolumen(float volumen)
    {
        PlayerPrefs.SetFloat(Volumen, volumen); // Guardar el volumen
        PlayerPrefs.Save(); // Asegurarse de que los cambios se guarden
    }

    public float GetVolumen()
    {
        return PlayerPrefs.GetFloat(Volumen, 1f); // Obtener el volumen guardado, por defecto es 1f (volumen máximo)
    }
}
