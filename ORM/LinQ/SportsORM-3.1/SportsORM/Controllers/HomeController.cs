using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomenLeagues = _context.Leagues
                .Where(league => league.Name.Contains("Womens"));
            ViewBag.HockeyLeagues = _context.Leagues
                .Where(league => league.Sport.Contains("Hockey"));
            ViewBag.NoFootballLeagues = _context.Leagues
                .Where(league => league.Sport != "Football");
            ViewBag.ConferencesLeagues = _context.Leagues
                .Where(league => league.Name.Contains("Conference"));
            ViewBag.AtlanticLeagues = _context.Leagues
                .Where(league => league.Name.Contains("Atlantic"));
            ViewBag.DallasTeams = _context.Teams
                .Where(team => team.Location == "Dallas");
            ViewBag.RaptorsTeams = _context.Teams
                .Where(team => team.TeamName == "Raptors");
            ViewBag.CityTeams = _context.Teams
                .Where(team => team.Location.Contains("City"));
            ViewBag.TTeams = _context.Teams
                .Where(team => team.TeamName.StartsWith("T"));
               
            ViewBag.AlphaTeams = _context.Teams
                .OrderBy(team => team.Location);
            ViewBag.ReverseAlphaTeams = _context.Teams
                .OrderByDescending(team => team.TeamName);
            ViewBag.LastNamePlayers = _context.Players
                .Where(player => player.LastName == "Cooper");
            ViewBag.FirstNamePlayers = _context.Players
                .Where(player => player.FirstName == "Joshua");
            ViewBag.ExceptionPlayers = _context.Players
                .Where(player => player.LastName == "Cooper" && player.FirstName != "Joshua");
            ViewBag.ExceptionFirstNamePlayers = _context.Players
                .Where(player => player.FirstName == "Alexander" || player.FirstName == "Wyatt");
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            ViewBag.ASCTeams = _context.Teams
            .Include(team => team.CurrLeague)
            .Where(team => team.CurrLeague.Name == "Atlantic Soccer Conference"); 

            ViewBag.PlayersPenguins = _context.Players
            .Include(player => player.CurrentTeam)
            .Where(player => player.CurrentTeam.TeamName == "Penguins");

            ViewBag.PlayersICBC = _context.Players
            .Include(player => player.CurrentTeam)
            .ThenInclude(team => team.CurrLeague)
            .Where(player => player.CurrentTeam.CurrLeague.Name == "International Collegiate Baseball Conference");

            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            ViewBag.SamTeams = _context.Players
            .Include(p => p.CurrentTeam)
            .Include(p => p.AllTeams)
            .ThenInclude(pt => pt.TeamOfPlayer)
            .Where(p => p.FirstName == "Samuel" && p.LastName == "Evans");

            ViewBag.PlayersManitoba = _context.Teams
            .Include(team => team.CurrentPlayers)
            .Include(team => team.AllPlayers)
            .ThenInclude(pt => pt.PlayerOnTeam)
            .Where(team => team.TeamName == "The Manitoba Tiger-Cats");
            return View();
        }

    }
}