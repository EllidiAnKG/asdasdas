

using System.Security.AccessControl;

/*!
	\brief Класс хронящий в себе все операции калькулятора
*/
public class Calculator
{
    /*!
	\brief функция сложения
*/
    public double Sum(double firstNumber, double secondNumber)
    {
        return firstNumber + secondNumber;
    }

/*!
	\brief функция умножения
*/
    public double Multi(double firstNumber, double secondNumber)
    {
        return firstNumber * secondNumber;
    }
    /*!
	\brief функция вычитания
*/

    public double Sub(double firstNumber, double secondNumber)
    {
        return firstNumber - secondNumber;
    }

/*!
	\brief функция деления
*/
    public double Div(double firstNumber, double secondNumber)
    {
        if (secondNumber == 0)
        {
            Calculator cal = new Calculator();
            Simple simp = new Simple(cal);
            Console.WriteLine("error:DivideByZeroException");
            simp.Simp();
            
        }
        return firstNumber / secondNumber;
    }
}
/*!
	\brief Родительский класс, не несущий никакой смысловой нагрузки
*/
public class Simple
{
    Calculator cal;
    /*!
	\brief Конструктор калькулятора 
*/
    public Simple(Calculator cal)
    {
        this.cal = cal;
    }
/*!
	\brief Класс Обрабытывающий запрос пользователя 
*/
    public void Simp()
    {
        bool check = true;
        double result = 0;

        try
        {
        Console.WriteLine("Введите первое число");
        double firstNumber = Convert.ToInt64(Console.ReadLine());
        

        while (check == true)
        {
            Console.WriteLine("Введите второе число");
            double secondNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Выберите метод");
            string method = Console.ReadLine();
            
            switch (method)
            {
                case "+":
                result = cal.Sum(firstNumber, secondNumber);
                Console.WriteLine(result);
                break;

                case "*":
                result = cal.Multi(firstNumber, secondNumber);
                Console.WriteLine(result);
                break;

                case "-":
                result = cal.Sub(firstNumber, secondNumber);
                Console.WriteLine(result);
                break;

                case "/":
                try
                {
                result = cal.Div(firstNumber, secondNumber);
                Console.WriteLine(result);
                }

                catch (DivideByZeroException ex){
                    Console.WriteLine("error" + ex);
                }
                break;
                default:
                Simple simp = new Simple(cal);
                Console.WriteLine("error:InvalidValueEntered");
                simp.Simp();
                break;
            }

            firstNumber = result;

            Console.WriteLine("Продолжить?");
            string question = Console.ReadLine();

            switch (question)
            {
                case "Нет":
                Console.WriteLine("Очистить калькулятор?");
                question = Console.ReadLine();
                if (question == "Да")
                {
                    Simp();
                }
                else
                {
                    check = false;
                }
                break;
            }
        }
        }
        catch (FormatException ex)
        {
            Console.WriteLine("ERR" + ex);
            Simple simp = new Simple(cal);
            simp.Simp();
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("ERR" + ex);
            Simple simp = new Simple(cal);
            simp.Simp();
        }

    }
}
/*!
	\brief Класс созданный для вызова других классов 
*/

public class Program
{
    
    static void Main()
    {
        Calculator cal = new Calculator();
        Simple simp = new Simple(cal);
        simp.Simp();
    }
}