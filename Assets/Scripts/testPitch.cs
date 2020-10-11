using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPitch : MonoBehaviour
{
    public AudioSource audio_E;
    public AudioSource audio_A;
    public AudioSource audio_D;
    public AudioSource audio_G;
    public AudioSource audio_B;
    public AudioSource audio_e;

    public float transpose = -4;  // transpose in semitones

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);

        float delay = 0.5f;

        for (int i = 0; i < 4; i++)
        {

            yield return StartCoroutine(MakeNote('A', 3, delay));
            yield return StartCoroutine(MakeNote('D', 5, delay));
            yield return StartCoroutine(MakeNote('A', 6, delay));
            //yield return StartCoroutine(MakeNote('A', 6, delay));
            yield return StartCoroutine(MakeNote('G', 5, delay));

            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator MakeNote(char line, int fret, float delay)
    {
        AudioSource audio = null;
        switch (line)
        {
            case 'E':
                audio = audio_E;
                break;
            case 'A':
                audio = audio_A;
                break;
            case 'D':
                audio = audio_D;
                break;
            case 'G':
                audio = audio_G;
                break;
            case 'B':
                audio = audio_B;
                break;
            case 'e':
                audio = audio_e;
                break;
            default:
                break;
        }

        if (audio != null)
        {
            audio.pitch = Mathf.Pow(2, (fret + transpose) / 12.0f);
            audio.Play();
        }

        yield return new WaitForSeconds(delay);
        audio.Stop();
    }

    /*
    void Update()
    {

        float note = -1; // invalid value to detect when note is pressed
        if (Input.GetKeyDown(KeyCode.Alpha0)) note = 0;  // C
        if (Input.GetKeyDown(KeyCode.Alpha1)) note = 2;  // D
        if (Input.GetKeyDown(KeyCode.Alpha2)) note = 4;  // E
        if (Input.GetKeyDown(KeyCode.Alpha3)) note = 5;  // F
        if (Input.GetKeyDown(KeyCode.Alpha4)) note = 7;  // G
        if (Input.GetKeyDown(KeyCode.Alpha5)) note = 9;  // A
        if (Input.GetKeyDown(KeyCode.Alpha6)) note = 11; // B
        if (Input.GetKeyDown(KeyCode.Alpha7)) note = 12; // C
        if (Input.GetKeyDown(KeyCode.Alpha8)) note = 14; // D

        if (note >= 0)
        { // if some key pressed...
            GetComponent<AudioSource>().pitch = Mathf.Pow(2, (note + transpose) / 12.0f);
            GetComponent<AudioSource>().Play();
        }
    }
     */
}
