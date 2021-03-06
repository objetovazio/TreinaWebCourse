﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinaWeb.Musicas.AcessoDados.Entity.Context;
using TreinaWeb.Musicas.Web.Identity;
using TreinaWeb.Musicas.Web.Models.Usuario;

namespace TreinaWeb.Musicas.Web.Controllers
{
    [AllowAnonymous]
    public class UsuariosController : Controller
    {
        public ActionResult CriarUsuario()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarUsuario(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>(new MusicasIdentityDbContext());
                var userManager = new UserManager<IdentityUser>(userStore);
                var identityUser = new IdentityUser
                {
                    UserName = usuarioViewModel.Email,
                    Email = usuarioViewModel.Email
                };
                IdentityResult identityResult = userManager.Create(identityUser, usuarioViewModel.Senha);

                if (identityResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("erro_identity", identityResult.Errors.First());
                    return View(usuarioViewModel);
                }
            }

            return View(usuarioViewModel);
        }

        public ActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>(new MusicasIdentityDbContext());
                var userManager = new UserManager<IdentityUser>(userStore);
                var identityUser = userManager.Find(viewModel.Email, viewModel.Senha);

                if(identityUser == null)
                {
                    ModelState.AddModelError("erro_identity", "Usuário e/ou senha incorreto.");
                    return View(viewModel);
                }

                var authManager = HttpContext.GetOwinContext().Authentication;
                var identity = userManager.CreateIdentity(identityUser, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties {
                    IsPersistent = false,}, identity);

                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);
        }

        [Authorize]
        public ActionResult Logoff()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}