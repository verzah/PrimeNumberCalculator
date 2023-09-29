using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Import System.IO in order to utilize StreamWriter to write the array to a file.
using System.IO;
namespace Project2Gavin
{
    public partial class Form1 : Form
    {
        //Initate variables
        //Creates a variable bool for two outcomes, identifies if the input is prime (true, false). 
        bool isPrime;
        //Creates a variable int, stores the count of prime numbers from the input to input + 100.
        int countPrimes;
        //Creates a variable array, prime numbers are transferred and stored in.
        int[] primesArray;
        public Form1()
        {
            InitializeComponent();
        }
        //Creates method that determines if a number is prime (true, false).
        private bool primeMethod(int input)
        {
            if (input == 0)
            {
                return false;
            }
            for (int i = 2; i < input; i++)
            {
                if (input % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        //Code for the click event on the Calculate Primes button.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //Clear output label.
            lblOutput.Text = "";
            //Display error if input textbox is empty.
            if (txtInput.Text == "")
            {
                MessageBox.Show("Please enter a number between 1 and 100!");
                return;
            }
            //Convert input to integer to calculate primes.
            int input = int.Parse(txtInput.Text);
            //Display error if input is not between 1 and 100.
            if (input < 1 || input > 100)
            {
                MessageBox.Show("Please enter a number between 1 and 100!");
                return;
            }
            //Increase input by 100 to define the range.
            int endRange = input + 100;
            //Creates variable to identify index of the array for output.
            int arrayIndex = 0;
            //Initializes array containing 100 zeroes.
            primesArray = new int[1000];
            //Creates for loop to identify prime numbers within range.
            for (int i = input; i < endRange; i++)
            {
                isPrime = primeMethod(i);
                if (isPrime == true)
                {
                    primesArray[arrayIndex] = i;
                    arrayIndex++;
                    countPrimes++;
                }
            }
            //Writes output to .txt.
            StreamWriter toFile = new StreamWriter("PrimeNumbers.txt");
            //Creates for loop to write array to .txt.
            for (int i = 0; i < primesArray.Length - 1; i ++)
            {
                toFile.WriteLine(primesArray[i]);
            }
            toFile.Close();
            //Displays output message in label
            lblOutput.Text = "There are " + countPrimes + " prime numbers between " + input + " and " + endRange + ". The first is " + primesArray[0] + " and the last is " + primesArray[countPrimes - 1] + ".";
        }
    }
}
