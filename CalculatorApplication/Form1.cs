namespace CalculatorApplication
{
    public partial class Form1 : Form
    {
        CalculatorClass cal = new CalculatorClass();//declaring variable for CalculatorClass
        public Form1(CalculatorClass cal)//instantiated inside the constructor of Form1
        {
            this.cal = cal;
            InitializeComponent();
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            try//error handling
            {
                double num1 = Convert.ToDouble(txtBoxInput1.Text);// the variable for num1 then convert it to double
                double num2 = Convert.ToDouble(txtBoxInput2.Text);//the variable for num2 
                string Operator = cbOperator.SelectedItem.ToString();//variable for selecting operator in combo box

                if (Operator == "+")//if sum got selected
                {//calling the event and show the answer in lblDisplayTotal
                    cal.CalculateEvent += new Formula<double>(cal.GetSum);
                    lblDisplayTotal.Text = cal.GetSum(num1,num2).ToString();
                    cal.CalculateEvent -= new Formula<double>(cal.GetSum);
                }
                else if (Operator == "-")//if minus got selected 
                {
                    cal.CalculateEvent += new Formula<double>(cal.GetDifference);
                    lblDisplayTotal.Text = cal.GetDifference(num1,num2).ToString();
                    cal.CalculateEvent -= new Formula<double>(cal.GetDifference);
                }
                else if (Operator == "*")//if times got selected
                {
                    cal.CalculateEvent += new Formula<double>(cal.GetMultiplication);
                    lblDisplayTotal.Text = cal.GetMultiplication(num1,num2).ToString();
                    cal.CalculateEvent -= new Formula<double>(cal.GetMultiplication);
                }
                else if (Operator == "/")//if divide got selected
                {
                    if (num2 != 0)//if the num2 is 0, it cannot divide
                    {
                        cal.CalculateEvent += new Formula<double>(cal.GetDivision);
                        lblDisplayTotal.Text = cal.GetDivision(num1, num2).ToString();
                        cal.CalculateEvent -= new Formula<double>(cal.GetDivision);
                    }
                    else
                    {
                        lblDisplayTotal.Text = "Cannot divide by zero";
                    }
                }
            }
            catch (Exception)//catch all exception then diplay this
            {
                MessageBox.Show("Please enter numbers and select the operator.");
            }
        }
        public delegate T Formula<T>(T num1, T num2);//declaring generic delegate 
        public class CalculatorClass
        {
            public Formula<double> Total; //declaring inside the class and set it to double 
            public event Formula<double> CalculateEvent//event accessor that confirms if its added and remove to delegate
            {
                add
                {
                    MessageBox.Show("Added the delegate");
                    Total += value;
                }
                remove
                {
                    MessageBox.Show("Removed the delegate");
                    Total -= value;
                }
            }
            public double GetSum(double num1, double num2)//methods that return adding two num
            {
                return num1 + num2;
            }
            public double GetDifference(double num1, double num2)//methods that return minus two num
            {
                return num1 - num2;
            }
            public double GetMultiplication(double num1, double num2)//methods that return multiply two num
            {
                return num1 * num2;
            }
            public double GetDivision(double num1, double num2)//methods that return dividing two num 
            {
                return num1 / num2;
            }
        }
        private void lblDisplayTotal_Click(object sender, EventArgs e)
        {
            lblDisplayTotal.Text = " ";
        }
    }
}