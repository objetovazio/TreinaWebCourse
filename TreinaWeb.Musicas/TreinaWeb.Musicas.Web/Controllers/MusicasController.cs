using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TreinaWeb.Musicas.AcessoDados.Entity.Context;
using TreinaWeb.Musicas.Dominio;
using TreinaWeb.Musicas.Repositorio.Comum;
using TreinaWeb.Musicas.Repositorio.Entity;
using TreinaWeb.Musicas.Web.Models.Album;
using TreinaWeb.Musicas.Web.Models.Musica;

namespace TreinaWeb.Musicas.Web.Controllers
{
    public class MusicasController : Controller
    {
        private IRepositorioGenerico<Musica, long> repositorioMusica
            = new MusicasRepositorio(new MusicasDbContext());

        private IRepositorioGenerico<Album, int> repositorioAlbum
            = new AlbumsRepositorio(new MusicasDbContext());

        public int AlbumModelView { get; private set; }


        // GET: Musicas
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Musica>, List<MusicaViewModel>>(repositorioMusica.Selecionar()));
        }

        // GET: Musicas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusica.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Musica, MusicaViewModel>(musica));
        }

        // GET: Musicas/Create
        public ActionResult Create()
        {
            List<Album> albums = repositorioAlbum.Selecionar();
            var map = Mapper.Map<List<Album>, List<AlbumViewModel>>(albums);
            ViewBag.IdAlbum = new SelectList(map, "Id", "Nome");
            return View();
        }

        // POST: Musicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,IdAlbum")] MusicaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Musica musica = Mapper.Map<MusicaViewModel, Musica>(viewModel);
                repositorioMusica.Inserir(musica);
                return RedirectToAction("Index");
            }

            List<Album> albums = repositorioAlbum.Selecionar();
            var map = Mapper.Map<List<Album>, List<AlbumViewModel>>(albums);
            ViewBag.IdAlbum = new SelectList(map, "Id", "Nome", viewModel.IdAlbum);
            return View(viewModel);
        }

        // GET: Musicas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusica.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }

            var mapMusica = Mapper.Map<Musica, MusicaViewModel>(musica);
            List<Album> albums = repositorioAlbum.Selecionar();
            var mapAlbums = Mapper.Map<List<Album>, List<AlbumViewModel>>(albums);


            ViewBag.IdAlbum = new SelectList(mapAlbums, "Id", "Nome", mapMusica.IdAlbum);
            return View(mapMusica);
        }

        // POST: Musicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,IdAlbum")] MusicaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Musica musica = Mapper.Map<MusicaViewModel, Musica>(viewModel);
                repositorioMusica.Alterar(musica);
                return RedirectToAction("Index");
            }

            List<Album> albums = repositorioAlbum.Selecionar();
            var mapAlbums = Mapper.Map<List<Album>, List<AlbumViewModel>>(albums);

            ViewBag.IdAlbum = new SelectList(mapAlbums, "Id", "Nome", viewModel.IdAlbum);
            return View(viewModel);
        }

        // GET: Musicas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusica.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Musica, MusicaViewModel>(musica));
        }

        // POST: Musicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            repositorioMusica.ExcluirPorId(id);
            return RedirectToAction("Index");
        }
    }
}
