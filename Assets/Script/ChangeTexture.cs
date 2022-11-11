using UnityEngine;
using UnityEngine.UI;


public class ChangeTexture : MonoBehaviour
{
    public Button btn_chooseBG_left;
    public Button btn_chooseBG_right;
    public RawImage rImg_bg;

    public Text txt_choosenBG;
    public Texture[] bgTextures;
    int bgIndex;


    public void Init()
    {
        rImg_bg.texture = bgTextures[bgIndex];
        txt_choosenBG.text = "Fondo " + bgIndex;


    }
    void OnEnable()
    {
        btn_chooseBG_left.onClick.AddListener(() => ChangeBGTexture(false));
    }

    void OnDisable()
    {
        btn_chooseBG_left.onClick.RemoveAllListeners();
    }
    public void ChangeBGTexture(bool _right)
    {
        if (_right)
        {
            bgIndex++;
            if (bgIndex >= bgTextures.Length) bgIndex = 0;
        }
        else
        {
            bgIndex--;
            if (bgIndex < 0) bgIndex = bgTextures.Length - 1;
        }

        rImg_bg.texture = bgTextures[bgIndex];
        txt_choosenBG.text = "Fondo " + bgIndex;
    }
}
