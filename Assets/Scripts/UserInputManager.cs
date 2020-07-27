using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;

public class UserInputManager : SingletonMonoBehavior<UserInputManager>
{
    IKeyboardListener mKeyboardListener = null;

    public void RegisterKeyboardListener(IKeyboardListener keyboardListener)
    {
        mKeyboardListener = keyboardListener;
    }

    public void UnregisterKeyboardListener(IKeyboardListener keyboardListener)
    {
        if (mKeyboardListener == keyboardListener)
            mKeyboardListener = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            var axisRaw = Input.GetAxisRaw("Horizontal");
            if (axisRaw != 0)
                mKeyboardListener?.OnHorizontalClick(axisRaw > 0);
        }
        if (Input.GetButtonDown("Vertical"))
        {
            var axisRaw = Input.GetAxisRaw("Vertical");
            if (axisRaw != 0)
                mKeyboardListener?.OnVerticalClick(axisRaw > 0);
        }
    }
}
