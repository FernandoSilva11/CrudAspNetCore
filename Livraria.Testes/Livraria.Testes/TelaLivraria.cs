using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using Selenium.Utils;
using Xunit;

namespace Livraria.Testes
{
    class TelaLivraria
    {
        private IConfiguration _configuration;
        private Browser _browser;
        private IWebDriver _driver;

        public TelaLivraria(
            IConfiguration configuration, Browser browser)
        {
            _configuration = configuration;
            _browser = browser;

            string caminhoDriver = null;
            if (browser == Browser.Firefox)
            {
                caminhoDriver =
                    _configuration.GetSection("Selenium:CaminhoDriverFirefox").Value;
            }
            else if (browser == Browser.Chrome)
            {
                caminhoDriver =
                    _configuration.GetSection("Selenium:CaminhoDriverChrome").Value;
            }

            _driver = WebDriverFactory.CreateWebDriver(
                browser, caminhoDriver);
        }

        public void CarregarPagina()
        {
            _driver.LoadPage(
                TimeSpan.FromSeconds(5),
                _configuration.GetSection("Selenium:UrlTelaLivraria").Value);
        }

        public void CadastrarLivro(Livro livro)
        {

            _driver.FindElement(By.XPath("//a[@href='/Livros/Create']")).Click();
            TimeSpan.FromSeconds(5);
            _driver.SetText(By.Id("Titulo"), livro.Titulo);
            _driver.SetText(By.Id("Sinopse"), livro.Sinopse);
            _driver.FindElement(By.Id("Preco")).Clear();
            _driver.SetText(By.Id("Preco"), livro.Preco.ToString());
            IWebElement checkEmEstoque = _driver.FindElement(By.Id("EmEstoque"));
            if (livro.EmEstoque)
            {
                checkEmEstoque.Click();
            }
            _driver.SetText(By.Id("Genero"), livro.Genero);
            _driver.SetText(By.Id("Escritor"), livro.Escritor);
            _driver.SetText(By.Id("ImagemUrl"), livro.ImagemUrl);
            _driver.FindElement(By.XPath("//*[@value='Criar']")).Click();
        }

        public void DetalhesLivro()
        {
            _driver.FindElement(By.XPath("//a[contains(@href,'/Livros/Details/')]")).Click();
            _driver.FindElement(By.XPath("//a[(@href='/')]")).Click();
        
        }
        public void EditarLivro(Livro livro)
        {
            _driver.FindElement(By.XPath("//a[contains(@href,'/Livros/Edit/')]")).Click();

            _driver.FindElement(By.Id("Preco")).Clear();
            _driver.SetText(By.Id("Preco"), livro.Preco.ToString());
            _driver.FindElement(By.XPath("//*[@value='Salvar']")).Click();
        }

        public void ExcluirLivro()
        {
            _driver.FindElement(By.XPath("//a[contains(@href,'/Livros/Delete/')]")).Click();
            _driver.FindElement(By.XPath("//*[@value='Deletar']")).Click();
        }

    }
}