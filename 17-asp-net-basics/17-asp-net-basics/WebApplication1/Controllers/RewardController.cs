using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BLL;
using Entities;
using Interfaces;
using WebApplication1.Models;
using System.Data.SqlClient;
using DAL.Database;

namespace WebApplication1.Controllers
{
    public class RewardController : Controller
    {
        //public IUserBL _userBl;
        public IRewardBL _rewardBl;
        
        public RewardController()
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = "localhost";
            connectionStringBuilder.InitialCatalog = "14-database-basics";
            connectionStringBuilder.IntegratedSecurity = true;

            var connectionString = connectionStringBuilder.ToString();

            var rewardsDAO = new RewardsDBDAO(connectionString);

            var rewardDBBL = new RewardBL(rewardsDAO);

            _rewardBl = rewardDBBL;
        }

        public IActionResult Index()
        {
            var rewards = _rewardBl.GetRewards();

            return View(rewards);
        }

        public IActionResult AddReward()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddReward(RewardEditVievModel reward)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var rewardToAdd = new Reward()
            {
                ID = reward.ID,
                Title = reward.Title,
                Description = reward.Description
            };

            _rewardBl.Add(rewardToAdd);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteReward(int id)
        {
            var rewardList = _rewardBl.GetRewards().ToList();
            var reward = rewardList.Find(reward => reward.ID == id);

            _rewardBl.Remove(reward);

            return RedirectToAction("Index");
        }

        public IActionResult EditReward(int id)
        {
            var rewardList = _rewardBl.GetRewards().ToList();
            var reward = rewardList.Find(reward => reward.ID == id);

            var rewardVM = new RewardEditVievModel()
            {
                ID = reward.ID,
                Title = reward.Title,
                Description = reward.Description
            };

            return View(rewardVM);
        }

        [HttpPost]
        public IActionResult EditReward(RewardEditVievModel reward)
        {
            var rewardList = _rewardBl.GetRewards().ToList();
            var mainReward = rewardList.Find(elem => elem.ID == reward.ID);

            if (!ModelState.IsValid)
            {
                return View();
            }

            var rewardToEdit = new Reward()
            {
                ID = reward.ID,
                Title = reward.Title,
                Description = reward.Description
            };

            _rewardBl.Edit(mainReward, rewardToEdit);

            return RedirectToAction("Index");
        }
    }
}
