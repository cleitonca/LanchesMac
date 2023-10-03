using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;

            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.Id);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                //if(string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                //{
                //    lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Normal")).OrderBy(l => l.Nome);
                //}
                //else
                //{
                //    lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Natural")).OrderBy(l => l.Nome);
                //}

                lanches = _lancheRepository.Lanches
                    .Where(L => L.Categoria.CategoriaNome.Equals(categoria))
                    .OrderBy(c => c.Nome);

                categoriaAtual = categoria;
            }

            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lanchesListViewModel);

        }

        public IActionResult Details(int LancheId)
        {
            var lanches = _lancheRepository.Lanches.FirstOrDefault(l => l.Id == LancheId);

            return View(lanches);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                lanches = _lancheRepository.Lanches.OrderBy(p => p.Id);
                categoriaAtual = "Todos os Lanches";
            }
            else
            {
                lanches = _lancheRepository.Lanches
                    .Where(p => p.Nome.ToLower().Contains(searchString.ToLower()));
                
                if (lanches.Any())
                {
                    categoriaAtual = "Lanches";
                }
                else
                {
                    categoriaAtual = "Nenehum lanche foi encontrado";
                }

            }

            return View("~/Views/Lanche/List.cshtml", new LancheListViewModel 
            { 
                Lanches = lanches, 
                CategoriaAtual = categoriaAtual 
            });

            return View();
        }

    }
}
