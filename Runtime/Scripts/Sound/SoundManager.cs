using toolbox.prefs;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource _AudioSourceSound;
    public AudioSource _AudioSourceEffects;
    
    public const string currentLevel = "currentLevel";
    public const string effectsStateOptions = "sound";
    public const string musicStateOptions = "music";
    public const string vibrationStateOptions = "vibration";
    public const bool effectsState = true;
    public const bool musicState = false;
    public const bool vibrationState = true;

    private bool isMusic;
    public bool MusicSoundState
    {
        get
        {
            isMusic = PlayerPrefsX.GetBool(musicStateOptions, musicState);
            return isMusic;
        }
        set
        {
            PlayerPrefsX.SetBool(musicStateOptions, value);
            muteStateAudiosource(_AudioSourceSound,value);
            isMusic = value;
        }
    }

    private bool isEffects;
    public bool EffectSoundState{
        get
        {
            isEffects = PlayerPrefsX.GetBool(effectsStateOptions, effectsState);
            return isEffects;
        }
        set
        {
            PlayerPrefsX.SetBool(effectsStateOptions, value);
            muteStateAudiosource(_AudioSourceEffects,value);
            isEffects = value;
        }
    }

    private bool isVibration;
    public bool VibrationState
    {
        get
        {
            isVibration = PlayerPrefsX.GetBool(vibrationStateOptions, vibrationState);
            return isVibration;
        }
        set
        {
            PlayerPrefsX.SetBool(vibrationStateOptions, value);
            isVibration = value;
        }
    }
    [HideInInspector]public static SoundManager instance;

    void loadConfig()
    {
        isMusic = MusicSoundState;
        isEffects = EffectSoundState;
        muteStateAudiosource(_AudioSourceSound,isMusic);
        muteStateAudiosource(_AudioSourceEffects,isEffects);
    }

    void Awake()
{
    if (instance == null)
    {
        instance = this;
        loadConfig();
        DontDestroyOnLoad(this.gameObject);
    }
    else
    {
      Destroy(this.gameObject);   
    }
}




public void playOneShot(AudioClip clip)
{
    if (isEffects)
    {
        _AudioSourceEffects.PlayOneShot(clip);
    }
    
}

public void muteStateAudiosource(AudioSource _source, bool state)
{
    _source.mute = !state;
}

}
