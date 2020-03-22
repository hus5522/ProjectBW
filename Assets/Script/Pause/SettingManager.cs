﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingManager : MonoBehaviour
{
    /*싱글톤*/
    public static SettingManager instance;

    #region Singleton
    private void Awake()
    {
        if (instance == null)
        {
            //DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion Singleton

    /*재생속도 상수 - 조정해야함*/
    public const float pv_1 = 0.1f;
    public const float pv_2 = 0.02f;
    public const float pv_3 = 0.005f;

    /*컬러*/
    private  Color32 color_select = new Color32 (255, 0, 0, 255);
    private Color32 color_unselect = new Color32 (255,255,255,255);
    private Color32 canvas_brightness = new Color32(0, 0, 0, 0);

    /*환경설정 변수 */
    private float brightness; //(0 - 100)
    private float bgmvolume; //(0 - 100)
    private float effectvolume; //(0 - 100)
    private float playvelocity;//(0-2)

    /*playerpref으로 유지되는 환경설정 변수 부가적으로 관리하도록 하기*/

    /*각종 조절 게임 오브젝트 변수*/
    public Slider brightness_S;
    public Slider bgmvolume_S;
    public Slider effectvolume_S;
 
    public Button play_slow_B;
    public Button play_mid_B;
    public Button play_fast_B;

    /*화면 밝기 조절용 이미지*/
    public Image BrightnessImage;

    void Start()
    {
        SetInitSetting();//기본 설정 적용하기 

        /*설정*/
        GetPrevSetting();//이전 설정 불러오기
        SetCurSetting();//현재 설정에 적용하기       
    }


    /*설정 변경 시 적용 - EventSystem On value changed 사용*/

    /*화면 밝기 조정*/
    public void UpdateBrightness()
    {
        if (UIManager.instance.GetIsPaused())
        {
            brightness = Mathf.RoundToInt(brightness_S.value);
            Debug.Log("brightness : " + brightness);
            SetCurSetting();//실제적용
        }
    }

    /*볼륨 조정*/
    public void UpdateBGMVolume()
    {
        if (UIManager.instance.GetIsPaused())
        {
            bgmvolume = Mathf.RoundToInt(bgmvolume_S.value);
            Debug.Log("bgmvolume : " + bgmvolume);
            SetCurSetting();//실제적용
        }
    }
    public void UpdateEffectVolume()
    {
        if (UIManager.instance.GetIsPaused())
        {
            effectvolume = Mathf.RoundToInt(effectvolume_S.value);
            Debug.Log("effectvolume : " + effectvolume);
            SetCurSetting();//실제적용
        }
    }

    /*자막 재생 속도 조정 - 버튼 눌렀을 때*/
    public void UpdatePlaySlow()
    {
        if (UIManager.instance.GetIsPaused())
        {
            playvelocity = 0f;
            EffectManager.instance.Play("버튼 클릭음");

            play_slow_B.image.color = color_select;
            play_mid_B.image.color = color_unselect;
            play_fast_B.image.color = color_unselect;

            Debug.Log("play velocity : slow");

            SetCurSetting();//실제적용
        }
    }
    public void UpdatePlayMid()
    {
        if (UIManager.instance.GetIsPaused())
        {
            playvelocity = 1f;
            EffectManager.instance.Play("버튼 클릭음");

            play_slow_B.image.color = color_unselect;
            play_mid_B.image.color = color_select;
            play_fast_B.image.color = color_unselect;

            Debug.Log("play velocity : mid");

            SetCurSetting();//실제적용
        }
    }
    public void UpdatePlayFast()
    {
        if (UIManager.instance.GetIsPaused())
        {
            playvelocity = 2f;
            EffectManager.instance.Play("버튼 클릭음");

            play_slow_B.image.color = color_unselect;
            play_mid_B.image.color = color_unselect;
            play_fast_B.image.color = color_select;

            Debug.Log("play velocity : fast");

            SetCurSetting();//실제적용
        }
    }

    /*저장 및 적용*/

    /*PlayerPref로부터 이전 설정 불러오기 */
    public void GetPrevSetting()
    {
        /*Load*/
        brightness = PlayerPrefs.GetFloat("Brightness");
        bgmvolume = PlayerPrefs.GetFloat("BGMVolume");
        effectvolume = PlayerPrefs.GetFloat("EffectVolume");
        playvelocity = PlayerPrefs.GetFloat("PlayVelocity");

        /*UI에 적용*/
        SetUISetting();

    }
    /*현재 설정 PlayerPref에 저장*/
    public void SaveCurSetting()
    {
        /*Save - 암호화 X*/
        PlayerPrefs.SetFloat("Brightness", brightness);
        PlayerPrefs.SetFloat("BGMVolume", bgmvolume);
        PlayerPrefs.SetFloat("EffectVolume", effectvolume);
        PlayerPrefs.SetFloat("PlayVelocity", playvelocity);
    }
    /*임시값을 실제값에 적용*/
    public void SetCurSetting()
    {
        /*화면*/
        int tmpbrightness = 100 - (int)brightness;
        canvas_brightness = new Color32 (0,0,0, (byte)tmpbrightness);
        BrightnessImage.GetComponent<Image>().color = canvas_brightness;

        /*볼륨*/
        BGMManager.instance.SetBGMVolume(bgmvolume*0.01f);
        EffectManager.instance.SetEffectVolume(effectvolume*0.01f);

        /*자막재생속도*/
        if (playvelocity == 0f)
        { DialogManager.instance.typingSpeed = pv_1; }
        else if (playvelocity == 1f)
        { DialogManager.instance.typingSpeed = pv_2; }
        else if (playvelocity == 2f)
        { DialogManager.instance.typingSpeed = pv_3; }
    }

    /*패널 열 때 UI설정 적용*/
    public void SetUISetting()
    {
        brightness_S.value = brightness;
        bgmvolume_S.value = bgmvolume;
        effectvolume_S.value = effectvolume;

        if (playvelocity == 0f)
        {
            play_slow_B.image.color = color_select;
            play_mid_B.image.color = color_unselect;
            play_fast_B.image.color = color_unselect;
        }
        else if (playvelocity == 1f)
        {
            play_slow_B.image.color = color_unselect;
            play_mid_B.image.color = color_select;
            play_fast_B.image.color = color_unselect;
        }
        else if (playvelocity == 2f)
        {
            play_slow_B.image.color = color_unselect;
            play_mid_B.image.color = color_unselect;
            play_fast_B.image.color = color_select;
        }
    }

    /*Init 환경설정*/
    public void SetInitSetting()
    {
        //PlayerPref에 데이터가 없으면 기본값을 적용하게 해야하나?
        brightness = 100f;
        bgmvolume = 100f;
        effectvolume = 100f;
        playvelocity = 1f;//mid       
    }
}
