using CoronaManagement.DAL;
using CoronaManagement.Models;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaManagement
{
    public class PatientDAL : IPatientDAL
    {
        private readonly CoronaPatientContext _context;


        public PatientDAL()
        {
            _context = new CoronaPatientContext();
        }

        public List<PersonalDetail> GetAllPatients()
        {
            return _context.PersonalDetails.ToList();
        }
        public int PostPatient(PersonalDetail personalDetail)
        {
            int isCreated = -1;
            _context.PersonalDetails.Add(personalDetail);
            isCreated = _context.SaveChanges();
            return isCreated;
        }
        public int ActivePatients(DateTime day)
        {
            var activePatients = (from p in _context.PersonalDetails
                                  join c in _context.CoronaDetails on p.PersonId equals c.PatientId
                                  where c.PositiveDate <= day && c.NegativeDate > day
                                  select p).ToList();
            return activePatients.Count();
        }
        public int NotVaccinated()
        {
            var notVaccinatedCount = (from p in _context.PersonalDetails
                                      where !_context.Vaccinations.Any(v => v.PatientId == p.PersonId)
                                      select p).Count();

            return notVaccinatedCount;
        }
        public async Task<int> PostImg(Byte[] fileBytes, string identity)
        {
           Task< int> id = FindPersonId(identity);
            Picture p = new Picture
            {
                Picture1 = fileBytes,
                PatientId = await id
            };
            await _context.Picture.AddAsync(p);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> FindPersonId(string identity)
        {
            var person= await _context.PersonalDetails.Where(p => p.PatientIdentity == identity).FirstOrDefaultAsync();
            int personId = person.PersonId;
            return personId;
        }

        public Task<int> PostImg(byte[] fileBytes, int id)
        {
            throw new NotImplementedException();
        }
    }
}
