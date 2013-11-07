using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

// Found somewhere on the net ... don't remember where

namespace ffmpeg {
	
    [DefaultEvent("OnValueChanged")]
    public partial class TimePicker : UserControl {
        [Browsable(true)]
        public event EventHandler OnValueChanged;

        public int Hours {
            get {
                string Part = TheTimeBox.Text.Split(":".ToCharArray())[0];
                int Value = 0;
                int.TryParse(Part, out Value);
                return Value;
            }
            set {
                string[] Parts = TheTimeBox.Text.Split(":".ToCharArray());
                string[] SecondParts = Parts[2].Split(".".ToCharArray());

                Parts[0] = value.ToString("D2");

                SetText(Parts[0], Parts[1], SecondParts[0], SecondParts[1]);
            }
        }
        public int Minutes {
            get {
                string Part = TheTimeBox.Text.Split(":".ToCharArray())[1];
                int Value = 0;
                int.TryParse(Part, out Value);
                return Value;
            }
            set  {
                string[] Parts = TheTimeBox.Text.Split(":".ToCharArray());
                string[] SecondParts = Parts[2].Split(".".ToCharArray());

                Parts[1] = value.ToString("D2");

                SetText(Parts[0], Parts[1], SecondParts[0], SecondParts[1]);
            }
        }
        public int Seconds  {
            get {
                string Part = TheTimeBox.Text.Split(":".ToCharArray())[2].Split(".".ToCharArray())[0];
                int Value = 0;
                int.TryParse(Part, out Value);
                return Value;
            }
            set {
                string[] Parts = TheTimeBox.Text.Split(":".ToCharArray());
                string[] SecondParts = Parts[2].Split(".".ToCharArray());

                SecondParts[0] = value.ToString("D2");

                SetText(Parts[0], Parts[1], SecondParts[0], SecondParts[1]);
            }
        }
        public int Milliseconds {
            get {
                string Part = TheTimeBox.Text.Split(":".ToCharArray())[2].Split(".".ToCharArray())[1];
                int Value = 0;
                int.TryParse(Part, out Value);
                return Value;
            }
            set {
                string[] Parts = TheTimeBox.Text.Split(":".ToCharArray());
                string[] SecondParts = Parts[2].Split(".".ToCharArray());

                SecondParts[1] = value.ToString("D3");

                SetText(Parts[0], Parts[1], SecondParts[0], SecondParts[1]);
            }
        }
        public TimeSpan Value {
            get {
                return new TimeSpan(0, Hours, Minutes, Seconds, Milliseconds);
            }
            set {
                Hours = value.Hours;
                Minutes = value.Minutes;
                Seconds = value.Seconds;
                Milliseconds = value.Milliseconds;
            }
        }

        public TimePicker() {
            InitializeComponent();

            TheTimeBox.LostFocus += new EventHandler(TheTimeBox_LostFocus);
            this.LostFocus += new EventHandler(TheTimeBox_LostFocus);
        }

        private void TheTimeBox_LostFocus(object sender, EventArgs e) {
            try {
                FormatText();
            } catch {}
        }
    
        private void FormatText() {
            string[] Parts = TheTimeBox.Text.Trim().Split(":".ToCharArray());
            
            int Hours = 0;
            if (!int.TryParse(Parts[0], out Hours))
                Hours = 0;
            if (Hours >= 24)
                Hours = 0;

            int Minutes = 0;
            if (!int.TryParse(Parts[1], out Minutes))
                Minutes = 0;
            if (Minutes >= 60)
                Minutes = 0;

            string[] SecondParts = Parts[2].Split(".".ToCharArray());
            
            int Seconds = 0;
            if (!int.TryParse(SecondParts[0], out Seconds))
                Seconds = 0;
            if (Seconds >= 60)
                Seconds = 0;

            int Milliseconds = 0;
            if (!int.TryParse(SecondParts[1], out Milliseconds))
                Milliseconds = 0;
            if (Milliseconds >= 1000)
                Milliseconds = 0;

            SetText(Hours.ToString("D2"),Minutes.ToString("D2"), Seconds.ToString("D2"), Milliseconds.ToString("D3"));
            if (OnValueChanged != null) {
                OnValueChanged.Invoke(null, new EventArgs());
            }
        }
        bool DoingFormatting = false;

        private void SetText(string Hour, string Minute, string Second, string Millisecond) {
            int SelectedIndex = TheTimeBox.SelectionStart;
            TheTimeBox.Text = Hour + ":" + Minute + ":" + Second + "." + Millisecond;
            SelectedIndex = SelectedIndex > TheTimeBox.Text.Length ? TheTimeBox.Text.Length : SelectedIndex;
            SelectCorrectText(SelectedIndex);
            if (!DoingFormatting) {
                DoingFormatting = true;
                FormatText();
                DoingFormatting = false;
            }
        }

        private void TheTimeBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Up) {
                string[] Parts = TheTimeBox.Text.Split(":".ToCharArray());
                string[] SecondParts = Parts[2].Split(".".ToCharArray());

                if (TheTimeBox.SelectionStart <= 2) {
                    int PartNum = 0;
                    if (int.TryParse(Parts[0], out PartNum)) {
                        PartNum++;
                        if (PartNum >= 100)
                            PartNum = 0;
                        Parts[0] = PartNum.ToString("D2");
                    }
                } else if (TheTimeBox.SelectionStart <= 5) {
                    int PartNum = 0;
                    if (int.TryParse(Parts[1], out PartNum)) {
                        PartNum++;
                        if (PartNum >= 60)
                            PartNum = 0;
                        Parts[1] = PartNum.ToString("D2");
                    }
                } else if (TheTimeBox.SelectionStart <= 8) {
                    int PartNum = 0;
                    if (int.TryParse(SecondParts[0], out PartNum)) {
                        PartNum++;
                        if (PartNum >= 60)
                            PartNum = 0;
                        SecondParts[0] = PartNum.ToString("D2");
                    }
                } else {
                    int PartNum = 0;
                    if (int.TryParse(SecondParts[1], out PartNum)) {
                        PartNum++;
                        if (PartNum >= 1000)
                            PartNum = 0;
                        SecondParts[1] = PartNum.ToString("D3");
                    }
                }
                SetText(Parts[0], Parts[1], SecondParts[0], SecondParts[1]);
                FormatText();
                e.Handled = true;
            } else if (e.KeyCode == Keys.Down) {
                string[] Parts = TheTimeBox.Text.Split(":".ToCharArray());
                string[] SecondParts = Parts[2].Split(".".ToCharArray());

                if (TheTimeBox.SelectionStart <= 2) {
                    int PartNum = 0;
                    if (int.TryParse(Parts[0], out PartNum)) {
                        PartNum--;
                        if (PartNum < 0)
                            PartNum = 23;
                        Parts[0] = PartNum.ToString("D2");
                    }
                } else if (TheTimeBox.SelectionStart <= 5) {
                    int PartNum = 0;
                    if (int.TryParse(Parts[1], out PartNum)) {
                        PartNum--;
                        if (PartNum < 0)
                            PartNum = 59;
                        Parts[1] = PartNum.ToString("D2");
                    }
                } else if (TheTimeBox.SelectionStart <= 8) {
                    int PartNum = 0;
                    if (int.TryParse(SecondParts[0], out PartNum)) {
                        PartNum--;
                        if (PartNum < 0)
                            PartNum = 59;
                        SecondParts[0] = PartNum.ToString("D2");
                    }
                } else {
                    int PartNum = 0;
                    if (int.TryParse(SecondParts[1], out PartNum)) {
                        PartNum--;
                        if (PartNum < 0) {
                            PartNum = 999;
                        }
                        SecondParts[1] = PartNum.ToString("D3");
                    }
                }
                SetText(Parts[0], Parts[1], SecondParts[0], SecondParts[1]);
                FormatText();
                e.Handled = true;
            } else if (e.KeyCode == Keys.Enter) {
                FormatText();
                e.Handled = true;
            } else if (e.KeyCode == Keys.Left) {
                FormatText();
                if (TheTimeBox.SelectionStart <= 2)
                    TheTimeBox.Select(9, 3);
                else if (TheTimeBox.SelectionStart <= 5)
                    TheTimeBox.Select(0, 2);
                else if (TheTimeBox.SelectionStart <= 8)
                    TheTimeBox.Select(3, 2);
                else
                    TheTimeBox.Select(6, 2);
                e.Handled = true;
            } else if (e.KeyCode == Keys.Right) {
                FormatText();
                if (TheTimeBox.SelectionStart <= 2)
                    TheTimeBox.Select(3, 2);
                else if (TheTimeBox.SelectionStart <= 5)
                    TheTimeBox.Select(6, 2);
                else if (TheTimeBox.SelectionStart <= 8)
                    TheTimeBox.Select(9, 3);
                else
                    TheTimeBox.Select(0, 2);
                e.Handled = true;
            } else if (!((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))) {
                NonNumKeyPressed = true;
                e.Handled = true;
            }
        }
        bool NonNumKeyPressed = false;
        private void SelectCorrectText(int SelectedIndex) {
            if (SelectedIndex <= 2)
                TheTimeBox.Select(0, 2);
            else if (SelectedIndex <= 5)
                TheTimeBox.Select(3, 2);
            else if (SelectedIndex <= 8)
                TheTimeBox.Select(6, 2);
            else
                TheTimeBox.Select(9, 3);
        }
        private void TheTimeBox_Click(object sender, EventArgs e) {
            FormatText();
        }

        private void TheTimeBox_TextChanged(object sender, EventArgs e) {
            if (NonNumKeyPressed) {
                NonNumKeyPressed = false;
                FormatText();
            }
        }
        
    }
    
}
