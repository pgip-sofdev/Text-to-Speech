using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;

namespace text_to_speech_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SpeechSynthesizer speechSynthesizerObj;

        private void Form1_Load(object sender, EventArgs e)
        {
            speechSynthesizerObj = new SpeechSynthesizer();
            btn_Resume.Enabled = false;
            btn_Pause.Enabled = false;
            btn_Stop.Enabled = false;
        }

        private void Btn_Speak_Click(object sender, EventArgs e)
        {
            speechSynthesizerObj = new SpeechSynthesizer();
            if(richTextBox1.Text!="")
            {
                speechSynthesizerObj = new SpeechSynthesizer();
                //Asynchronously speaks the content present in RichTextBox1
                speechSynthesizerObj.SpeakAsync(richTextBox1.Text);
                btn_Pause.Enabled = true;
                btn_Stop.Enabled = true;
            }
        }

        private void Btn_Pause_Click(object sender, EventArgs e)
        {
            if (speechSynthesizerObj != null)
            {
                //Gets the current speaking state of the SpeechSyntesizer object.
                if (speechSynthesizerObj.State == SynthesizerState.Speaking)
                {
                    //Pauses the SpeechSynthesizer object.
                    speechSynthesizerObj.Pause();
                    btn_Resume.Enabled = true;
                    btn_Speak.Enabled = false;
                }
            }
        }

        private void Btn_Resume_Click(object sender, EventArgs e)
        {
            if (speechSynthesizerObj != null)
            {
                if (speechSynthesizerObj.State == SynthesizerState.Paused)
                {
                    //Resumes the SpeechSynthesizer
                    speechSynthesizerObj.Resume();
                    btn_Resume.Enabled = false;
                    btn_Speak.Enabled = true;
                }
            }
        }

        private void Btn_Stop_Click(object sender, EventArgs e)
        {
            if(speechSynthesizerObj != null)
            {
                //Disposes the SpeechSynthesis object
                speechSynthesizerObj.Dispose();
                btn_Speak.Enabled = true;
                btn_Resume.Enabled = false;
                btn_Pause.Enabled = false;
                btn_Stop.Enabled = false;
            }
        }
    }
}
