using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL.Database;
using DAL.List;
using Entities;
using Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        public IUserBL _userBl;
        public IRewardBL _rewardBl;


        public UserController()
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = "localhost";
            connectionStringBuilder.InitialCatalog = "14-database-basics";
            connectionStringBuilder.IntegratedSecurity = true;

            var connectionString = connectionStringBuilder.ToString();

            var rewardsDAO = new RewardsDBDAO(connectionString);
            var usersDAO = new UsersDBDAO(connectionString);

            var rewardDBBL = new RewardBL(rewardsDAO);
            var userDBBL = new UserBL(usersDAO);

            _userBl = userDBBL;
            _rewardBl = rewardDBBL;
        }

        public IActionResult Index()
        {
            var users = _userBl.GetUsers();

            return View(users);
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(UserEditVievModel user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var userToAdd = new User()
            {
                ID = user.ID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birthdate = user.Birthdate
            };

            _userBl.Add(userToAdd);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            var usersList = _userBl.GetUsers().ToList();
            var user = usersList.Find(user => user.ID == id);

            _userBl.Remove(user);

            return RedirectToAction("Index");
        }

        public IActionResult EditUser(int id)
        {
            var usersList = _userBl.GetUsers().ToList();
            var user = usersList.Find(user => user.ID == id);

            var allTitleRewardsList = new List<String>();

            foreach (var reward in _rewardBl.GetRewards())
            {
                allTitleRewardsList.Add(reward.Title);
            }

            var userRewards = _userBl.GetUsers().ToList().Find(user => user.ID == id).Rewards;

            if (userRewards == null)
            {
                userRewards = new string[] { };
            }

            List<SelectListItem> selectedRewards = new List<SelectListItem>();

            foreach (var reward in allTitleRewardsList.ToArray())
            {
                if (userRewards.Contains(reward))
                {
                    selectedRewards.Add(new SelectListItem(reward, reward, true));
                    continue;
                }
                selectedRewards.Add(new SelectListItem(reward, reward, false));
            }

            var userVM = new UserEditVievModel()
            {
                ID = user.ID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birthdate = user.Birthdate,
                userSelectRewards = selectedRewards
            };


            return View(userVM);
        }

        [HttpPost]
        public IActionResult EditUser(UserEditVievModel user)
        {
            var usersList = _userBl.GetUsers().ToList();
            var mainUser = usersList.Find(elem => elem.ID == user.ID);


            if (!ModelState.IsValid)
            {
                return View();
            }

            var userRewardsList = new List<string>();

            foreach (var reward in user.userSelectRewards)
            {
                if (reward.Selected)
                {
                    userRewardsList.Add(reward.Value);
                }
            }

            var userToEdit = new User()
            {
                ID = user.ID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birthdate = user.Birthdate,
                Rewards = userRewardsList.ToArray()
            };

            _userBl.Edit(mainUser, userToEdit);

            return RedirectToAction("Index");
        }

        public IActionResult EditUserRewards(int id)
        {
            var usersList = _userBl.GetUsers().ToList();
            var user = usersList.Find(user => user.ID == id);

            var allTitleRewardsList = new List<String>();

            foreach (var reward in _rewardBl.GetRewards())
            {
                allTitleRewardsList.Add(reward.Title);
            }

            var userRewards = _userBl.GetUsers().ToList().Find(user => user.ID == id).Rewards;

            if (userRewards == null)
            {
                userRewards = new string[] {};
            }

            List<SelectListItem> selectedRewards = new List<SelectListItem>();

            foreach (var reward in allTitleRewardsList.ToArray())
            {
                if (userRewards.Contains(reward))
                {
                    selectedRewards.Add(new SelectListItem(reward, reward, true));
                    continue;
                }
                selectedRewards.Add(new SelectListItem(reward, reward, false));
            }

            var userVM = new UserEditVievModel()
            {
                ID = user.ID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birthdate = user.Birthdate,
                userSelectRewards = selectedRewards
            };

            return View(userVM);
        }

    }
}
