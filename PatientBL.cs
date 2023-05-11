using CoronaManagement.DAL;
using CoronaManagement.Models;
using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaManagement.BL
{
    public class PatientBL : IPatientBL
    {
        private IPatientDAL _patientDAL;

        public PatientBL(IPatientDAL patientDAL)
        {
            _patientDAL = patientDAL;
        }
        public List<PersonalDetail> GetDetails()
        {
            return _patientDAL.GetAllPatients();
        }
        public int PostPatient(PersonalDetail personalDetail)
        {
            return _patientDAL.PostPatient(personalDetail);
        }
        public int ActivePatients(DateTime day)
        {
            return _patientDAL.ActivePatients(day);
        }
        public int NotVaccinated()
        {
            return _patientDAL.NotVaccinated();
        }
        public async Task<int> PostImg(Picture picture, int id)
        {
            IFormFile file = picture.File;
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    Byte[] fileBytes = ms.ToArray();
                    return await _patientDAL.PostImg(fileBytes, id);
                }
            }
            return -1;
        }

        //public Task GetPatientById(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
