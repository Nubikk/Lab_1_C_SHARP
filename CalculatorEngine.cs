using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Lab1
{
   
    public class CalculatorEngine
    {
        protected bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        protected bool isOperator(string str)
        {
            switch(str) {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return true;
            }
            return false;
        }

        public string Process(string str)
        {
            
            List<string> parts = str.Split(' ').ToList<string>();
            string result;
           
            while(parts.Count > 1)
            {
                
                if(!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
                {
                    return "E";
                } else
                {
                    
                    result = calculate(parts[1], parts[0], parts[2], 4);
                    
                    parts.RemoveRange(0, 3);
                    
                    parts.Insert(0, result);
                }
            }
            return parts[0];
        }
        public string unaryCalculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = Math.Sqrt(Convert.ToDouble(operand));
                       
                        parts = result.ToString().Split('.');
                        
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        
                        return result.ToString("N" + remainLength);
                    }
                case "1/x":
                    if(operand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1.0 / Convert.ToDouble(operand));
                        
                        parts = result.ToString().Split('.');
                        
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        
                        return result.ToString("N" + remainLength);
                    }
                    break;
            }
            return "E";
        }

        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":

                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));

                        parts = result.ToString().Split('.');

                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }

                        remainLength = maxOutputSize - parts[0].Length - 1;

                        return result.ToString("N" + remainLength);
                    }
                    else 
                    {
                        string message = "Error division by 0";
                        string caption = "Error ";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;
                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            // Closes the parent form.
                            return "Error";
                        }

                    }
                    break;
                case "%":
                    
                    break;
            }
            return "E";
        }
    }
}
