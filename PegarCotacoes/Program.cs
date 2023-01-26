using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V106.Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegarCotacoes
{
    class PegarCotacoes
    {
        public static string BuscarDolar()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com.br");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input")).SendKeys("cotação dólar");
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input")).SendKeys(Keys.Enter);
            string cotacao_dolar = driver.FindElement(By.XPath("//*[@id=\"knowledge-currency__updatable-data-column\"]/div[1]/div[2]/span[1]")).GetAttribute("data-value");
            float dolar = float.Parse(cotacao_dolar, CultureInfo.InvariantCulture.NumberFormat);
            string textodolar = $"O valor do dólar hoje é: {dolar:c}";
            Console.WriteLine(textodolar);
            driver.Quit();
            driver = null;
            return textodolar;
        }
        public static string BuscarEuro()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com.br");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input")).SendKeys("cotação euro");
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input")).SendKeys(Keys.Enter);
            string cotacao_euro = driver.FindElement(By.XPath("//*[@id=\"knowledge-currency__updatable-data-column\"]/div[1]/div[2]/span[1]")).GetAttribute("data-value");
            float euro = float.Parse(cotacao_euro, CultureInfo.InvariantCulture.NumberFormat);
            string textoeuro = $"O valor do euro hoje é: {euro:c}";
            Console.WriteLine(textoeuro);
            driver.Quit();
            driver = null;
            return textoeuro;
        }
        public static string BuscarOuro()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.melhorcambio.com/ouro-hoje");
            driver.Manage().Window.Maximize();
            string cotacao_ouro = driver.FindElement(By.XPath("//*[@id=\"comercial\"]")).GetAttribute("value");
            float ouro = float.Parse(cotacao_ouro);
            string textoouro = $"O valor do ouro hoje é: {ouro:c}";
            Console.WriteLine(textoouro);
            driver.Quit();
            driver = null;
            return textoouro;
        }
        static void Main()
        {
            string dolarhoje = BuscarDolar();
            string eurohoje = BuscarEuro();
            string ourohoje = BuscarOuro();
            Console.Clear();
            Console.WriteLine(dolarhoje);
            Console.WriteLine(eurohoje);
            Console.WriteLine(ourohoje);
            Console.WriteLine("Busca por cotações realizada.");
            Console.ReadLine();
        }
    }
}
