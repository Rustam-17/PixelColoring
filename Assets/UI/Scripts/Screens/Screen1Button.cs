using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen1Button : MonoBehaviour
{
    [SerializeField] GameObject _screen;
    [SerializeField] GameObject _levelButtons;
    [SerializeField] List<LevelScreen> _levelScreens;

    public void TryReturnToScreen()
    {
        if (_screen.activeSelf)
        {
            foreach (LevelScreen levelScreen in _levelScreens)
            {
                levelScreen.gameObject.SetActive(false);
            }

            _levelButtons.SetActive(true);
        }
    }
}
