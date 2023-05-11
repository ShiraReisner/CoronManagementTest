using CoronaManagement.Models;
using Entities;

namespace CoronaManagement.BL
{
    public interface IPatientBL
    {
        List<PersonalDetail> GetDetails();
        int PostPatient(PersonalDetail personalDetail);
        int ActivePatients(DateTime day);
        int NotVaccinated();
         Task<int> PostImg(Picture picture, int id);
        //Task GetPatientById(int id);
    }
}