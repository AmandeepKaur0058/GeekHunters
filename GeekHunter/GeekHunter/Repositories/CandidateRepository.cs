using Dapper;
using GeekHunter.Models;
using System.Collections.Generic;
using System.Linq;
using GeekHunter.Database;

namespace GeekHunter.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        public CandidateRepository()
        {
            
        }

        public Candidate GetCandidateById(int id)
        {
            using (var cnn = DatabaseManager.SimpleDbConnection())
            {
                cnn.Open();
                return cnn.Query<Candidate>(
                    @"SELECT c.Id, c.FirstName,c.LastName,c.SkillId,s.Name As SkillName
                                 FROM Candidate c
                                 JOIN Skill     s ON c.SkillId = s.Id
                                 WHERE c.Id = @Id",new{Id=id}).FirstOrDefault();
            }
        }
        public  List<Candidate> GetCandidate()
        {
            using (var cnn = DatabaseManager.SimpleDbConnection())
            {
                cnn.Open();
                return cnn.Query<Candidate>(
                    @"SELECT c.Id, c.FirstName,c.LastName,c.SkillId,s.Name As SkillName
                                 FROM Candidate c
                                 JOIN Skill     s ON c.SkillId = s.Id").ToList();
            }
        }

        public List<Candidate> GetCandidateBySkillId(int skillId)
        {
            using (var cnn = DatabaseManager.SimpleDbConnection())
            {
                cnn.Open();
                return cnn.Query<Candidate>(
                    @"SELECT c.Id, c.FirstName,c.LastName,c.SkillId,s.Name As SkillName
                                 FROM Candidate c
                                 JOIN Skill     s ON c.SkillId = s.Id",new{Id = skillId}).ToList();
            }
        }

        public int CreateNewCandidate(Candidate candidate)
        {
            using (var cnn = DatabaseManager.SimpleDbConnection())
            {
                cnn.Open();
              return  cnn.Query<int>(
                    @"INSERT INTO Candidate
                            (FirstName, LastName,SkillId)
                             VALUES(@FirstName,@LastName,@SkillId);
                            
                       SELECT last_insert_rowid() As id
                     ", candidate).FirstOrDefault();
            }
            
        }
        public List<Candidate> GetCandidatesByTechnology(int skillId)
        {
            using (var cnn = DatabaseManager.SimpleDbConnection())
            {
                cnn.Open();
                return cnn.Query<Candidate>(@"SELECT c.Id, c.FirstName,c.LastName,c.SkillId,s.Name As SkillName
                                                                FROM Candidate c
                                                                JOIN Skill     s ON c.SkillId = s.Id
                                                                WHERE SkillId = @SkillId", new {SkillId = skillId}).ToList();
            }
        }

        public Candidate DeleteCandidateById(int id)
        {
            using (var cnn = DatabaseManager.SimpleDbConnection())
            {
                cnn.Open();
                return cnn.Query<Candidate>(@"DELETE FROM Candidate
                                         WHERE Id = @Id", new {Id = id}).FirstOrDefault();
            }
        }

        public Candidate UpdateCandidate(Candidate candidate)
        {
            using (var cnn = DatabaseManager.SimpleDbConnection())
            {
                cnn.Open();
                return cnn.Query<Candidate>(@"UPDATE Candidate
                                         SET FirstName = @FirstName, LastName = @LastName,SkillId = @SkillId
                                          WHERE Id = @Id",candidate).FirstOrDefault();
            }
        }
    }
}