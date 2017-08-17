using GeekHunter.Models;
using GeekHunter.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeekHunter.Test
{
    [TestClass]
    public class TestCandidate
    {
        [TestMethod]
        public void GeekHunter_CreateCandidate()
        {
            CandidateRepository candidateRepository = new CandidateRepository();
            Candidate candidate = new Candidate
            {
                FirstName = "Jimmy",
                LastName = "Simson",
                SkillId = 3
            };
            int id = candidateRepository.CreateNewCandidate(candidate);
            var candidateResult = candidateRepository.GetCandidateById(id);

            Assert.AreEqual(candidate.FirstName, candidateResult.FirstName);
            Assert.AreEqual(candidate.LastName, candidateResult.LastName);
            Assert.AreEqual(candidate.SkillId, candidateResult.SkillId);
        }
        
        [TestMethod]
        public void GeekHunter_GetCandidates()
        {
            CandidateRepository candidateRepository = new CandidateRepository();
            var list = candidateRepository.GetCandidate().Count;
            Candidate candidate = new Candidate
            {
                FirstName = "kim",
                LastName = "Simson",
                SkillId = 4
            };
            candidateRepository.CreateNewCandidate(candidate);
            Candidate candidate2 = new Candidate
            {
                FirstName = "Priya",
                LastName = "Sood",
                SkillId = 2
            };
            candidateRepository.CreateNewCandidate(candidate2);
            var list2 = candidateRepository.GetCandidate().Count;

            Assert.IsTrue(list2 > list);
        }
        [TestMethod]
        public void GeekHunter_SearchCandiatesBySkill_ReturnListOfCandidatesByGivenId()
        {
            CandidateRepository candidateRepository = new CandidateRepository();
            Candidate candidate = new Candidate
            {
                FirstName = "Aman",
                LastName = "Kaur",
                SkillId = 1

            };
            candidateRepository.CreateNewCandidate(candidate);
            var getcandidates = candidateRepository.GetCandidatesByTechnology(candidate.SkillId).Count;
            
            Assert.IsTrue(getcandidates > 0);
        }

        [TestMethod]
        public void GeekHunterTest_DeleteCandidateById()
        {
            CandidateRepository candidateRepository = new CandidateRepository();
            Candidate candidate = new Candidate
            {
                FirstName = "Aman",
                LastName = "Kaur",
                SkillId = 1

            };
            int id = candidateRepository.CreateNewCandidate(candidate);
            var candidateList = candidateRepository.GetCandidate().Count;
            candidateRepository.DeleteCandidateById(id);

            var newCandidateList = candidateRepository.GetCandidate().Count;

            Assert.IsTrue(newCandidateList < candidateList);

        }

        [TestMethod]
        public void GeekHunterTest_UpdateCandidate()
        {
            CandidateRepository candidateRepository = new CandidateRepository();
            Candidate candidate = new Candidate
            {
                FirstName = "Julia",
                LastName = "Dsousa",
                SkillId = 2
            };
            int id = candidateRepository.CreateNewCandidate(candidate);
            Candidate candidate2 = new Candidate
            {
                FirstName = "John",
                LastName = "Dsousa",
                SkillId = 2,
                Id = id
        };
            
            candidateRepository.UpdateCandidate(candidate2);

            var updatedCandidate = candidateRepository.GetCandidateById(id);


            Assert.AreNotEqual(candidate.FirstName, updatedCandidate.FirstName);
            Assert.AreEqual(candidate.LastName, updatedCandidate.LastName);
            Assert.AreEqual(candidate.SkillId, updatedCandidate.SkillId);
        }
    }
}
