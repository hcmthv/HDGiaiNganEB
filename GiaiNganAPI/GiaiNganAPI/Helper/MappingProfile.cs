using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using erpsolution.dal.EF;
using erpsolution.entities.HR;
using erpsolution.entities.SystemMaster;

namespace erpsolution.api.Helper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<HrMasEmployee , EmployeeModel>().ReverseMap();
            CreateMap<HrMasEplAcademy, EmployeeAcademyModel>().ReverseMap();
            CreateMap<HrMasEplAppraisal, EmployeeAppraisalModel>().ReverseMap();
            CreateMap<HrMasEplBasic, EmployeeBasicModel>().ReverseMap();
            CreateMap<HrMasEplCetificate, EmployeeCetificateModel>().ReverseMap();
            CreateMap<HrMasEplContract, EmployeeContractModel>().ReverseMap();
            CreateMap<HrMasEplFamily, EmployeeFamilyModel>().ReverseMap();
            CreateMap<HrMasEplInsurance, EmployeeInsuranceModel>().ReverseMap();
            CreateMap<HrMasEplLastCareer, EmployeeLastCareerModel>().ReverseMap();
            CreateMap<HrMasEplMedical, EmployeeMedicalModel>().ReverseMap();
            CreateMap<HrMasEplPathCareer, EmployeePathCareerModel>().ReverseMap();
            CreateMap<HrMasEplTraining, EmployeeTrainingModel>().ReverseMap();
            CreateMap<HrMasEplReward, EmployeeRewardModel>().ReverseMap();
            CreateMap<ZmMasSharingUser, MasSharingGroupUserModel>().ReverseMap();
            CreateMap<ZmMasSharingGroup, MasSharingGroupModel>().ReverseMap();

        }
    }
}
