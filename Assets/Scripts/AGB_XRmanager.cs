using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AGB_XRmanager : MonoBehaviour
{
    //private InputDevice targetDevice;

    // �߰��ؾ� �Ұ� ������ư �ѽ�°�

    public AGB_SwordSelecter swordSelecter;

    private bool _isRtrigger = false;
    private bool _isLtrigger = false;

    bool _isPressRtrigger = false;
    bool _isPressLtrigger = false;
    public bool _isPause;

    bool _isPlaying = true;
    bool _isConCont = false;

    private InputDevice _rightController;
    private InputDevice _leftController;

    
    private void OnEnable()
    {
        GetDevice();
    }
 
   
    

    #region ��Ʈ�ѷ�

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
        Debug.Log($"{device.name} : {device.characteristics}");
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
        while (_leftController.isValid && _isPlaying)
        {

            _rightController.TryGetFeatureValue(CommonUsages.triggerButton, out _isRtrigger);
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
            _leftController.TryGetFeatureValue(CommonUsages.triggerButton, out _isLtrigger);
            if (_isLtrigger)
                Debug.Log("LTrigger pressed " + _isLtrigger);

            //_rightController.TryGetFeatureValue(CommonUsages.primaryButton, out _isRtrigger);
            //_leftController.TryGetFeatureValue(CommonUsages.primaryButton, out _isRtrigger);


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
