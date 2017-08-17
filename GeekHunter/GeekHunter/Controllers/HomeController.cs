using System.Collections.Generic;
using System.Web.Mvc;
using GeekHunter.Models;
using GeekHunter.Repositories;

namespace GeekHunter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly ISkillRepository _skillRepository;

        public HomeController(ICandidateRepository candidateRepository, ISkillRepository skillRepository)
        {
            _candidateRepository = candidateRepository;
            _skillRepository = skillRepository;
        }

        public ActionResult Index()
        {
            List<Candidate> result = _candidateRepository.GetCandidate();
            List<SelectListItem> listItems = _skillRepository.SkillListItems();
            var viewModel = new DisplayCandidateViewModel() { SkillListItems = listItems, Candidates = result };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Heading = "Create Candidate";

            List<SelectListItem> listItems = _skillRepository.SkillListItems();
            var viewModel = new CreateCandidateViewModel { SkillListItems = listItems };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CreateCandidateViewModel viewModel)   
        {
            if (!ModelState.IsValid)
            {
                viewModel.SkillListItems = _skillRepository.SkillListItems();
                return View(viewModel);
            }
            var candidate = new Candidate()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                SkillId = viewModel.SkillId
            };
            _candidateRepository.CreateNewCandidate(candidate);

            return RedirectToAction("Index");
        }

        public ActionResult Search(DisplayCandidateViewModel viewModel)
        {
            viewModel.Candidates = _candidateRepository.GetCandidatesByTechnology(viewModel.SkillId);
            viewModel.SkillListItems = _skillRepository.SkillListItems();
            return View("Index", viewModel);
        }

        public ActionResult ClearFilter()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Delete(DisplayCandidateViewModel viewModel)
        {

            _candidateRepository.DeleteCandidateById(viewModel.Id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {

            ViewBag.Heading = "Update Candidate";
            var candidate = _candidateRepository.GetCandidateById(id);
            List<SelectListItem> listItems = _skillRepository.SkillListItems();

            var viewModel = new CreateCandidateViewModel()
            {
                FirstName = candidate.FirstName,
                LastName = candidate.LastName,
                SkillId = candidate.SkillId,
                SkillListItems = listItems,
                Id = candidate.Id

            };
            return View("Create", viewModel);
        }
        [HttpPost]
        public ActionResult Update(CreateCandidateViewModel viewModel, int id)
        {
            ViewBag.Heading = "Update Candidate";

            if (!ModelState.IsValid)
            {
                viewModel.SkillListItems = _skillRepository.SkillListItems();
                return View("Create",viewModel);
            }

            var candidate = new Candidate();
            candidate.FirstName = viewModel.FirstName;
            candidate.LastName = viewModel.LastName;
            candidate.SkillId = viewModel.SkillId;
            candidate.Id = viewModel.Id;

            _candidateRepository.UpdateCandidate(candidate);

            return RedirectToAction("Index", new { id = viewModel.Id });


        }


    }
}