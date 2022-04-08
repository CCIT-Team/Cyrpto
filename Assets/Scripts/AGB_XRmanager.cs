using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AGB_XRmanager : MonoBehaviour
{
    //private InputDevice targetDevice;

    // 추가해야 할것 정지버튼 총쏘는거

    public AGB_SwordSelecter swordSelecter;
    //public AGB_GameManager gameManager;

    private bool _isRtrigger = false;
    private bool _isLtrigger = false;

    bool _isPressRtrigger = false;
    bool _isPressLtrigger = false;
    

    bool _isPlaying = true;
    bool _isConCont = false;

    private InputDevice _rightController;
    private InputDevice _leftController;

    private bool _isRPrimaryBtn = false;
    private bool _isLPrimaryBtn = false;
    


    private void OnEnable()
    {
        GetDevice();
    }
 
   
    

    #region 컨트롤러

    private IEnumerator RightController(InputDevice device, InputDeviceCharacteristics characteristics)
    {
        var devices = new List<InputDevice>();

        do
        {
            yield return null;
            InputDevices.GetDevicesWithCharacteristics(characteristics, devices);
            if (devices.Count > 0)
                _rightController = devices[0];
        } while (devices.Count == 0);

        if (!_isConCont)
            StartCoroutine(GetKey());
        
    }

    private IEnumerator LeftController(InputDevice device, InputDeviceCharacteristics characteristics)
    {
        var devices = new List<InputDevice>();

        do
        {
            yield return null;
            InputDevices.GetDevicesWithCharacteristics(characteristics, devices);
            if (devices.Count > 0)
                _leftController = devices[0];
        } while (devices.Count == 0);

        if (!_isConCont)
            StartCoroutine(GetKey());
        Debug.Log($"{device.name} : {device.characteristics}");
    }
    void GetDevice()
    {


        var characteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        StartCoroutine(RightController(_rightController, characteristics));

        characteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        StartCoroutine(LeftController(_leftController, characteristics));


      

    
    }

    IEnumerator GetKey()
    {
        _isConCont = true;
        while ((_leftController.isValid || _rightController.isValid) && _isPlaying)
        {
            //검전환
            _rightController.TryGetFeatureValue(CommonUsages.triggerButton, out _isRtrigger);
            _rightController.TryGetFeatureValue(CommonUsages.primaryButton, out _isRPrimaryBtn);
            _leftController.TryGetFeatureValue(CommonUsages.primaryButton, out _isLPrimaryBtn);

            if (_isRtrigger&& !_isPressRtrigger)
            {
                _isPressRtrigger = true;
                swordSelecter.SelectSword(true);
            }
            else if (!_isRtrigger && _isPressRtrigger)
            {
                _isPressRtrigger = false;
                swordSelecter.SelectSword(false);
           

            }

            ////총트리거
            //_leftController.TryGetFeatureValue(CommonUsages.triggerButton, out _isLtrigger);
            //if (_isLtrigger)


            if (_isRPrimaryBtn && !AGB_GameManager._inst._isPause)
            {
                AGB_GameManager._inst._isPause = true;
                AGB_GameManager._inst.BtnGamePause(0);
            }
            if (_isLPrimaryBtn && !AGB_GameManager._inst._isPause)
            {
                AGB_GameManager._inst._isPause = true;
                AGB_GameManager._inst.BtnGamePause(1);
            }
           
         


            if (!_isPlaying)
            {
                _isConCont = false;
                GetDevice();

            }
            yield return null;
        }
        _isConCont = false;
        GetDevice();

    }

    #endregion

}
