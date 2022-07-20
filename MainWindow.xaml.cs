using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Operation operation;
        String buttonContent;
        double currentValue=0;
        double otherValue=0;
        double finalValue=0;

        public enum Operation
        {
            Addition,
            Subtraction,
            Multiplication,
            Division
        }

        public MainWindow()
        {
            InitializeComponent();

                      
        }

        

        private void btnNumberClicks(object sender, RoutedEventArgs e)
        {
            int selectedNumber = 0;

            if (sender == btn0)
                selectedNumber = 0;
            if (sender == btn1)
                selectedNumber = 1;
            if (sender == btn2)
                selectedNumber = 2;
            if (sender == btn3)
                selectedNumber = 3;
            if (sender == btn4)
                selectedNumber = 4;
            if (sender == btn5)
                selectedNumber = 5;
            if (sender == btn6)
                selectedNumber = 6;
            if (sender == btn7)
                selectedNumber = 7;
            if (sender == btn8)
                selectedNumber = 8;
            if (sender == btn9)
                selectedNumber = 9;

            txtBox.Text += selectedNumber.ToString();
            

        }

        private void Multiplication(object sender, RoutedEventArgs e)
        {
            operation = Operation.Multiplication;
            if (currentValue == 0) currentValue = float.Parse(txtBox.Text);
            txtBox.Clear();
        }

        private void Subtraction(object sender, RoutedEventArgs e)
        {
            operation = Operation.Subtraction;
            if (currentValue == 0) currentValue = float.Parse(txtBox.Text);
            txtBox.Clear();
        }

        private void Addition(object sender, RoutedEventArgs e)
        {
            operation = Operation.Addition;
            if (currentValue == 0) currentValue = float.Parse(txtBox.Text);
            txtBox.Clear();
            
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            buttonContent = null;
            txtBox.Clear();

        }

        private void Equal(object sender, RoutedEventArgs e)
        {
            if (otherValue == 0) otherValue = float.Parse(txtBox.Text);

            if (currentValue != 0 && otherValue != 0)
            {
                if (operation == Operation.Addition) finalValue = currentValue + otherValue;
                else if (operation == Operation.Subtraction) finalValue = currentValue - otherValue;
                else if (operation == Operation.Multiplication) finalValue = currentValue * otherValue;
                else if (operation == Operation.Division) finalValue = currentValue / otherValue;
                
                if (finalValue != 0) txtBox.Text = finalValue.ToString();
                finalValue = currentValue = otherValue = 0;
            }

            
        }

      

        private void bPoint_click(object sender, RoutedEventArgs e)
        {
            string str = txtBox.Text;
            if(!str.Contains("."))
            {
                txtBox.Text += ".";
            }
        }


        private double getCurrentValue()
        {
            currentValue = Convert.ToDouble(txtBox.Text);
            return currentValue;
        }

        private double getOtherValue()
        {

            if (txtBox.Text == null)
            {

                otherValue = getCurrentValue();

            }

            return otherValue;

        }

        private double getFinalValue()
        {

            return finalValue;

        }

        private void Division(object sender, RoutedEventArgs e)
        {
            operation = Operation.Division;
            if (currentValue == 0) currentValue = float.Parse(txtBox.Text);
            txtBox.Clear();
        }
    }
}
