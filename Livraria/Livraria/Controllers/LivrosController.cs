using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Models.Context;
using Livraria.Models.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    public class LivrosController : Controller
    {
        private readonly Contexto _contexto;

       public LivrosController(Contexto contexto)
        {
            _contexto = contexto;
        }
        public IActionResult Index()
        {
            var lista = _contexto.Livro.ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var livro = new Livros();
            return View(livro);
        }

        [HttpPost]
        public IActionResult Create(Livros livro)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(livro);
                _contexto.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(livro);
        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var livro = _contexto.Livro.Find(Id);
            return View(livro);
        }


        [HttpPost]
        public IActionResult Edit(Livros livro)
        {
            if (ModelState.IsValid)
            {
                _contexto.Livro.Update(livro);
                _contexto.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(livro);
            }

        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var livro = _contexto.Livro.Find(Id);
            return View(livro);
        }


        [HttpPost]
        public IActionResult Delete(Livros _livro)
        {
            var livro = _contexto.Livro.Find(_livro.Id) ;
            if (livro!=null)
            {
                _contexto.Livro.Remove(livro);
                _contexto.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(livro);
            }
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            var livro = _contexto.Livro.Find(Id);
            return View(livro);
        }


    }
}