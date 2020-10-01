using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrostweepGames.Plugins.GoogleCloud.SpeechRecognition
{
    public class VoiceRecognizer : MonoBehaviour
    {
        [SerializeField]
        private GCSpeechRecognition speechRecognition;
        [SerializeField]
        private TextHandler textHandler;

        void Start()
        {
            speechRecognition.RecognizeSuccessEvent += RecognizeSuccessEventHandler;

            speechRecognition.FinishedRecordEvent += FinishedRecordEventHandler;
            speechRecognition.StartedRecordEvent += StartedRecordEventHandler;
            speechRecognition.RecordFailedEvent += RecordFailedEventHandler;

            speechRecognition.BeginTalkigEvent += BeginTalkigEventHandler;
            speechRecognition.EndTalkigEvent += EndTalkigEventHandler;

            Debug.Log(speechRecognition.GetMicrophoneDevices()[MicroPhoneSetter.nowValue]);
            speechRecognition.SetMicrophoneDevice(speechRecognition.GetMicrophoneDevices()[MicroPhoneSetter.nowValue]);
            speechRecognition.StartRecord(true);
        }

        void OnDestroy()
        {
			speechRecognition.RecognizeSuccessEvent -= RecognizeSuccessEventHandler;

			speechRecognition.FinishedRecordEvent -= FinishedRecordEventHandler;
			speechRecognition.StartedRecordEvent -= StartedRecordEventHandler;
			speechRecognition.RecordFailedEvent -= RecordFailedEventHandler;

			speechRecognition.EndTalkigEvent -= EndTalkigEventHandler;
        }

        void RecognizeSuccessEventHandler(RecognitionResponse recognitionResponse){
            Debug.Log(recognitionResponse);
            if (recognitionResponse == null || recognitionResponse.results.Length == 0)
            {
                Debug.Log("Words not detected.");
                return;
            }
            var words = recognitionResponse.results[0].alternatives[0].words;
            Debug.Log(words);
            if (words == null) return;
            foreach (var item in words)
            {
                textHandler.OnChangeText(item.word);
            }
        }

        private void FinishedRecordEventHandler(AudioClip clip, float[] raw)
        {
            Debug.Log("Finished Record");

            RecognitionConfig config = RecognitionConfig.GetDefault();
            config.languageCode = Enumerators.LanguageCode.ja_JP.Parse();
            config.audioChannelCount = clip.channels;
            // configure other parameters of the config if need

            GeneralRecognitionRequest recognitionRequest = new GeneralRecognitionRequest()
            {
                audio = new RecognitionAudioContent()
                {
                    content = raw.ToBase64()
                },
                //audio = new RecognitionAudioUri() // for Google Cloud Storage object
                //{
                //	uri = "gs://bucketName/object_name"
                //},
                config = config
            };

            speechRecognition.Recognize(recognitionRequest);
        }

        private void StartedRecordEventHandler()
        {
            Debug.Log("Record Started");
        }

        private void RecordFailedEventHandler()
        {
            Debug.Log("Record Failed");
        }

        private void BeginTalkigEventHandler()
        {
            Debug.Log("Begin Talking");
        }

        private void EndTalkigEventHandler(AudioClip clip, float[] raw)
        {
            Debug.Log("End Talking");

            FinishedRecordEventHandler(clip, raw);
        }
    }
}