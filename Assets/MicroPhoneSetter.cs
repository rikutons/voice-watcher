using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FrostweepGames.Plugins.GoogleCloud.SpeechRecognition
{
    public class MicroPhoneSetter : MonoBehaviour
    {
        public static int nowValue = 0;
        [SerializeField]
        private GCSpeechRecognition speechRecognition;
        [SerializeField]
        private Dropdown microphoneDevicesDropdown;
        // Start is called before the first frame update
        void Start()
        {
            microphoneDevicesDropdown.ClearOptions();

            for (int i = 0; i < speechRecognition.GetMicrophoneDevices().Length; i++)
            {
                microphoneDevicesDropdown.options.Add(new Dropdown.OptionData(speechRecognition.GetMicrophoneDevices()[i]));
            }
        }

        public void OnValueChanged(int value){
            nowValue = value;
        }
    }
}