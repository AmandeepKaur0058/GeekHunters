using System.Collections.Generic;
using GeekHunter.Models;

namespace GeekHunter.Repositories
{
    public interface ICandidateRepository
    {
        Candidate GetCandidateById(int id);
        int CreateNewCandidate(Candidate candidate);
        List<Candidate> GetCandidate();
        List<Candidate> GetCandidatesByTechnology(int skillId);
        List<Candidate> GetCandidateBySkillId(int skillId);
        Candidate DeleteCandidateById(int id);
        Candidate UpdateCandidate(Candidate candidate);
    }
}