using CoronaManagement.Models;

namespace CoronaManagement
{
    public interface IPatientDAL
    {
        List<PersonalDetail> GetAllPatients();
        int PostPatient(PersonalDetail personalDetail);
        int NotVaccinated();
        int ActivePatients(DateTime day);
        Task<int> PostImg(Byte[] fileBytes, int id);
        Task<int> FindPersonId(string identity);
    }
}