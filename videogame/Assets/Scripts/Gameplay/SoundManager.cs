/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)
    
Modification Date: 27/04/21

Functionality: 
    This script manages what sounds and music to play across all other scripts
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    //define sound manager audio clips to use
    [SerializeField] AudioClip musicArea1;
    [SerializeField] AudioClip musicArea2;
    [SerializeField] AudioClip musicArea3;
    [SerializeField] AudioClip battleMusic;
    [SerializeField] AudioClip bossMusic;
    [SerializeField] AudioClip correctAnswer;
    [SerializeField] AudioClip incorrectAnswer;
    [SerializeField] AudioClip menuSelect1;
    [SerializeField] AudioClip menuSelect2;
    [SerializeField] AudioClip menuSelect3;
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip faintSound;
    [SerializeField] AudioClip textSound;

    public bool isInCombat;

    //to be able to get audio clip properties from other scripts
    public AudioClip MusicArea1 {get {return musicArea1;} }
    public AudioClip MusicArea2 {get {return musicArea2;} }
    public AudioClip MusicArea3 {get {return musicArea1;} }
    public AudioClip BattleMusic {get {return battleMusic;} }
    public AudioClip BossMusic {get {return bossMusic;} }
    public AudioClip CorrectAnswer {get {return correctAnswer;} }
    public AudioClip IncorrectAnswer {get {return incorrectAnswer;} }
    public AudioClip MenuSelect1 {get {return menuSelect1;} }
    public AudioClip MenuSelect2 {get {return menuSelect2;} }
    public AudioClip MenuSelect3 {get {return menuSelect3;} }
    public AudioClip HitSound {get {return hitSound;} }
    public AudioClip FaintSound {get {return faintSound;} }
    public AudioClip TextSound {get {return textSound;} }

    public bool IsInCombat {get {return isInCombat;} }

    public static SoundManager Instance { get; private set; }

    //instance to use sound manager properties
    private void Awake()
    {
        Instance = this;
    }

    //function to play background music in the freeroam state, and loop it if the music has stopped
    public void normalBackgroundMusic()
    {
        AudioSource audio = GetComponent<AudioSource>();
        int currentArea = SceneManager.GetActiveScene().buildIndex-1;

        if (GameController.Instance.Area1Idx.IndexOf(currentArea) != -1)
        {
            if (!audio.isPlaying || audio.clip != musicArea1)
            {
                audio.Stop();
                audio.clip = musicArea1;
                audio.volume = 0.4f;
                audio.Play();
            }
        }
        else if (GameController.Instance.Area2Idx.IndexOf(currentArea) != -1)
        {
            if (!audio.isPlaying || audio.clip != musicArea2)
            {
                audio.Stop();
                audio.clip = musicArea2;
                audio.volume = 0.4f;
                audio.Play();
            }
        }
        if (GameController.Instance.Area3Idx.IndexOf(currentArea) != -1)
        {
            if (!audio.isPlaying || audio.clip != musicArea3)
            {
                audio.Stop();
                audio.clip = musicArea3;
                audio.volume = 0.4f;
                audio.Play();
            }
        }
    }

    //function to play combat music, and play different clips based on what enemy is encountered
    public void battleBackgroundMusic(string programName)
    {
        AudioSource audio = GetComponent<AudioSource>();

        if (programName.Contains("Boss"))
        {
            if ((!audio.isPlaying || audio.clip != bossMusic) && isInCombat)
            {
                audio.Stop();
                audio.clip = bossMusic;
                audio.volume = 0.4f;
                audio.Play();
            }
        }
        else
        {
            if ((!audio.isPlaying || audio.clip != battleMusic) && isInCombat)
            {
                audio.Stop();
                audio.clip = battleMusic;
                audio.volume = 0.4f;
                audio.Play();
            }
        }
    }

    //function to stop all current music
    public void stopMusic()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Stop();
    }

    //function to play a sound effect selected audio clip defined as property 
    public void playSoundEffect(AudioClip soundEffect)
    {
        AudioSource audio = GetComponent<AudioSource>();

        if (soundEffect == textSound)
            audio.PlayOneShot(soundEffect, 0.1f);
        else
            audio.PlayOneShot(soundEffect, 0.2f);
    }
}
