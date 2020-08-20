using Microsoft.Extensions.Configuration;
using Selenium.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Livraria.Testes
{
    public class TestesLivraria
    {
        private IConfiguration _configuration;
        public TestesLivraria()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            _configuration = builder.Build();
        }
        [Theory]
        [InlineData(Browser.Firefox)]

        public void TestarLivraria(
            Browser browser)
        {
            TelaLivraria tela =
               new TelaLivraria(_configuration, browser);
            
            var livro = new Livro
            {
                Titulo = "Nome do Vento",
                Sinopse = "Conheça a historia",
                Preco = 39.90M,
                EmEstoque = true,
                Genero = "Fantasia",
                Escritor = "Patrick Rothfuss",
                ImagemUrl = "https://d1pkzhm5uq4mnt.cloudfront.net/imagens/capas/4933a5903532d562b5db1269c8d9c3862c40edeb.jpg"
            };

           tela.CarregarPagina();
           tela.CadastrarLivro(livro);
           tela.DetalhesLivro();
           livro.Preco = 49.90M;
           tela.EditarLivro(livro);
           tela.ExcluirLivro();
        }
    }
}
