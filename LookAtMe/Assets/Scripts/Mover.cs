using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Mover : MonoBehaviour
{
    private InputDevice _device;
    private CharacterController _character;
    private Vector2 _inputAxis; //where to move

    // Start is called before the first frame update
    private void Start()
    {
        _device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand); //input source를 그냥 하드코딩으로 넣어줄 수도 있음
        _character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        _device.TryGetFeatureValue(CommonUsages.primary2DAxis, out _inputAxis);
        //조이스틱 움직이거나 안 움직이거나 암튼 그 좌표 가져와서 _inputAxis 변수에 넣음
        _character.Move(motion: new Vector3(_inputAxis.x, y: 0, z: _inputAxis.y) * Time.deltaTime * 1f);
    }
}
