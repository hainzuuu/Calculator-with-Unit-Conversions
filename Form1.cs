using System.Data;

namespace calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox2.Text += "\n\n";
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            labelDisplay.Text += "0";
        }

        private void buttonOne_Click(object sender, EventArgs e)
        {
            labelDisplay.Text += "1";
        }

        private void buttonTwo_Click(object sender, EventArgs e)
        {
            labelDisplay.Text += "2";
        }

        private void buttonThree_Click(object sender, EventArgs e)
        {
            labelDisplay.Text += "3";
        }

        private void buttonFour_Click(object sender, EventArgs e)
        {
            labelDisplay.Text += "4";
        }

        private void buttonFive_Click(object sender, EventArgs e)
        {
            labelDisplay.Text += "5";
        }

        private void buttonSix_Click(object sender, EventArgs e)
        {
            labelDisplay.Text += "6";
        }

        private void buttonSeven_Click(object sender, EventArgs e)
        {
            labelDisplay.Text += "7";
        }

        private void buttonEight_Click(object sender, EventArgs e)
        {
            labelDisplay.Text += "8";
        }

        private void buttonNine_Click(object sender, EventArgs e)
        {
            labelDisplay.Text += "9";
        }
        private void buttonDot_Click(object sender, EventArgs e)
        {
            labelDisplay.Text += ".";
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            labelDisplay.Text += "+";

        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            labelDisplay.Text += "-";
        }

        private void buttonTimes_Click(object sender, EventArgs e)
        {
            labelDisplay.Text += "x";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            labelDisplay.Text += "÷";
        }

        private void buttonAC_Click(object sender, EventArgs e)
        {
            allClear();

        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            if (labelDisplay.Text.Length > 0)
            {
                labelDisplay.Text = labelDisplay.Text.Remove(labelDisplay.Text.Length - 1, 1);
                labelAnswer.Text = "0 =";
            }
            
        }

        public void allClear()
        {
            labelDisplay.Text = "";
            labelAnswer.Text = "0 =";
        }

        public static double convertFrom;

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            int histIndex = 0;
            String[] histArray = new string[100];
            String display = labelDisplay.Text;
            String Formula = display.Replace("÷", "/").Replace("x", "*");
            bool noError = true;

            if (Formula.IndexOf("√") != 0)
            {
                try
                {
                    string answer = new DataTable().Compute(Formula, null).ToString();

                    if (answer != "∞")
                    {
                        convertFrom = double.Parse(answer);

                        histArray[histIndex] = Formula;
                        histIndex++;

                        if (double.Parse(answer) < 0)
                        {
                            histArray[histIndex] = answer;
                            histIndex++;

                            answer = (double.Parse(answer) * -1).ToString();
                            labelAnswer.Text = answer + "- =";
                        }
                        else
                        {
                            histArray[histIndex] = answer;
                            histIndex++;
                            labelAnswer.Text = answer + " =";

                        }
                    }
                    else
                    {
                        noError = false;
                        MessageBox.Show("Invalid Expression", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        allClear();
                    }

                }
                catch
                {
                    noError = false;
                    MessageBox.Show("Invalid Expression", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                histArray[histIndex] = Formula;
                histIndex++;
                Formula = display.Remove(0, 1);

                try
                {
                    double answer = Math.Sqrt(double.Parse(Formula));
                    convertFrom = answer;

                    histArray[histIndex] = answer + "";
                    histIndex++;
                    labelAnswer.Text = answer + " =";
                }
                catch
                {
                    noError = false;
                    MessageBox.Show("Invalid Expression", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            int displayIndex = 0;
            if (noError)
            {
                
                if (displayIndex > 0)
                {
                    richTextBox2.Text += "\n";
                }
                richTextBox2.Text += "\n" + histArray[displayIndex] + " = " + histArray[displayIndex + 1];
                displayIndex++;
                richTextBox2.Text += "\n-------------------";
            }

            

        }

        private void buttonSquareroot_Click(object sender, EventArgs e)
        {
            labelDisplay.Text += "√";
            
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            convert();
        }

        public void convert()
        {
            double inchValue = 0;
            double convertTo = 0;
            string nameFrom = "";
            string nameTo = "";
            bool noSelectFrom = false;
            bool noSelectTo = false;

            if (fromInch.Checked)
            {
                inchValue = convertFrom;
                nameFrom = "in";
            }
            else if (fromFoot.Checked)
            {
                inchValue = convertFrom * 12;
                nameFrom = "Ft";
            }
            else if (fromYard.Checked)
            {
                inchValue = convertFrom * 36;
                nameFrom = "yd";
            }
            else if (fromMile.Checked)
            {
                inchValue = convertFrom * 63360;
                nameFrom = "mi";
            }
            else if (fromCentimeter.Checked)
            {
                inchValue = convertFrom / 2.54;
                nameFrom = "cm";
            }
            else if (fromMeter.Checked)
            {
                inchValue = convertFrom * 39.3701;
                nameFrom = "m";
            }
            else if (fromKilometer.Checked)
            {
                inchValue = convertFrom * 39370.07874;
                nameFrom = "km";
            }
            else
            {
                noSelectFrom = true;
            }

            if (toInch.Checked)
            {
                convertTo = inchValue;
                nameTo = "in";
            }
            else if (toFoot.Checked)
            {
                convertTo = inchValue / 12;
                nameTo = "Ft";
            }
            else if (toYard.Checked)
            {
                convertTo = inchValue / 36;
                nameTo = "yd";
            }
            else if (toMile.Checked)
            {
                convertTo = inchValue / 63360;
                nameTo = "mi";
            }
            else if (toCentimeter.Checked)
            {
                convertTo = inchValue * 2.54;
                nameTo = "cm";
            }
            else if (toMeter.Checked)
            {
                convertTo = inchValue / 39.3701;
                nameTo = "m";
            }
            else if (toKilometer.Checked)
            {
                convertTo = inchValue / 39370.07874;
                nameTo = "km";
            }
            else
            {
                noSelectTo = true;
            }

            if (noSelectTo != true && noSelectFrom != true)
            {
                labelConvert.Text = convertFrom + nameFrom + " = " + Math.Round(convertTo, 2) + nameTo;
            }
            else
            {
                MessageBox.Show("Choose a conversion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBoxFrom_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Do you want to clear history?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                richTextBox2.Text = "\n\n";
            }

        }
    }
}